using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrintMe.API.Services;
using PrintMe.Application.Constants;
using PrintMe.Application.Entities;
using PrintMe.Application.Enums;
using PrintMe.Application.Interfaces;
using PrintMe.Application.Interfaces.Repositories;
using PrintMe.Application.Model;

namespace PrintMe.API.Controllers;

// [Authorize]
public class CatalogController : BaseController
{
    private readonly ICatalogService _catalogService;
    private readonly IImageRepository _imageRepository;
    private readonly IQueueRepository _queueRepository;

    public CatalogController(ILogger<CatalogController> logger, ICatalogService catalogService, IImageRepository imageRepository, IQueueRepository queueRepository) : base(logger)
    {
        _catalogService = catalogService;
        _imageRepository = imageRepository;
        _queueRepository = queueRepository;
    }

    [HttpGet]
    [Authorize(Policy = "Admin")]
    public async Task<ActionResult> GetCatalogItems([FromQuery] PaginationRequest paginationRequest)
    {
        var items = await _catalogService.GetCatalogItems(paginationRequest);
        return Ok(items);
    }

    [HttpPost("items-by-ids")]
    public async Task<ActionResult> GetCatalogItems([FromBody] int[] ids)
    {
        if (ids.Length.Equals(0))
        {
            return BadRequest("No id provided.");
        }

        var items = await _catalogService.GetItemsByIds(ids);
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CatalogItem>> GetCatalogItem([FromRoute] int id)
    {
        if (id < 1)
        {
            return BadRequest("Id is not valid.");
        }

        var catalogItem = await _catalogService.GetCatalogItem(id);

        if (catalogItem == null)
        {
            return NotFound();
        }

        return Ok(catalogItem);
    }
    
    [HttpGet("custom-product")]
    public async Task<ActionResult<CatalogItem>> GetCustomCatalogItem()
    {
        var customProduct = await _catalogService.GetCustomCatalogItem();

        if (customProduct == null)
        {
            return NotFound();
        }

        return Ok(customProduct);
    }

    [HttpPost("search")]
    public async Task<ActionResult> SearchCatalogItems([FromBody] CatalogItemSearchRequest searchRequest)
    {
        var items = await _catalogService.SearchCatalogItems(searchRequest);
        return Ok(items);
    }

    [HttpGet("search")]
    public async Task<ActionResult> GetCatalogItemsFiltered([FromQuery] CatalogItemSearchRequest searchRequest)
    {
        var items = await _catalogService.SearchCatalogItems(searchRequest);
        return Ok(items);
    }


    [HttpPut("{id}")]
    [Authorize(Policy = "Admin")]
    public async Task<IActionResult> UpdateCatalogItem([FromRoute] int id, [FromBody] UpdateCatalogItemRequest catalogItem)
    {
        if (id != catalogItem.Id)
        {
            return BadRequest();
        }

        await _catalogService.UpdateCatalogItem(catalogItem);

        return NoContent();
    }

    [HttpPost]
    [Authorize(Policy = "Admin")]
    public async Task<ActionResult<CatalogItem>> CreateCatalogItem(CatalogItem catalogItem)
    {
        await _catalogService.CreateCatalogItem(catalogItem);

        return CreatedAtAction(nameof(GetCatalogItem), new { id = catalogItem.Id }, catalogItem);
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = "Admin")]
    public async Task<IActionResult> DeleteCatalogItem(int id)
    {
        await _catalogService.DeleteCatalogItem(id);

        return NoContent();
    }

    [HttpGet("/test")]
    [Authorize(Policy = "User")]
    public IActionResult AuthorizationTest()
    {
        return Ok();
    }

    public class UploadProductImagesRequest
    {
        public string FolderName { get; set; }
        public IFormFile Image { get; set; }
        public IFormFile? ImageAlternate { get; set; }
        public IFormFile? Thumbnail { get; set; }
        public IFormFile? ThumbnailAlternate { get; set; }
        public List<IFormFile>? OtherImages { get; set; } = new List<IFormFile>();
    }

    [Obsolete("Use GenerateProductByImage instead.")]
    [HttpPost("upload-product-images")]
    public async Task<IActionResult> UploadImages([FromForm] UploadProductImagesRequest request)
    {
        // if (await _imageRepository.DoesFolderExistAsync(request.FolderName))
        // {
        //     return BadRequest("Folder already exists.");
        // }

        await using var imageStream = request.Image.OpenReadStream();
        await using var imageAlternateStream = request.ImageAlternate?.OpenReadStream();
        await using var thumbnailStream = request.Thumbnail?.OpenReadStream();
        await using var thumbnailAlternateStream = request.ThumbnailAlternate?.OpenReadStream();

        List<Stream> otherImageStreams = new List<Stream>();
        foreach (var otherImage in request.OtherImages)
        {
            otherImageStreams.Add(otherImage.OpenReadStream());
        }

        await _imageRepository.UploadImageAsync(request.FolderName, imageStream, imageAlternateStream, thumbnailStream, thumbnailAlternateStream, otherImageStreams);
        return Ok("Images uploaded successfully.");
    }

    [HttpGet("get-image-urls")]
    public async Task<IActionResult> GetImageUrls([FromQuery] string folderName)
    {
        var imagesDto = await _imageRepository.GetImageUrlsAsync(folderName);
        return Ok(imagesDto);
    }

    public class GenerateProductByImageDto
    {
        public IEnumerable<IFormFile> Images { get; set; }
        public CatalogTags? Tag { get; set; }
        public List<int> TemplateIds { get; } = new ();
        public bool IsVertical { get; set; } = false;
    }

    [HttpPost("generate-product-by-image")]
    public async Task<IActionResult> GenerateProductByImage([FromForm] GenerateProductByImageDto dto)
    {
        foreach (var image in dto.Images)
        {
            var templates = RetrieveRandomTemplates(dto);
            var imageId = Guid.NewGuid().ToString();
            await using var imageStream = image.OpenReadStream();
            var url = await _imageRepository.UploadBlobAsync(imageId, imageStream);

            var messageContent = new ImageProcessMessage
            {
                ImageId = imageId,
                ImageUrl = url,
                ImageDescription = image.FileName,
                Tag = dto.Tag,
                MockupTemplates = templates
            };

            await _queueRepository.SendImageProcessMessageAsync(messageContent);
        }

        return Ok();
    }

    private static List<MockupTemplate> RetrieveRandomTemplates(GenerateProductByImageDto dto)
    {
        var templates = new List<MockupTemplate>();
        var verticalTemplates = MockupTemplates.GetMockupTemplates()
            .Where(x => x.Type == (dto.IsVertical ? MockupTemplateType.VerticalForVerticalFrame : MockupTemplateType.VerticalForHorizontalFrame))
            .ToList();
        templates.Add(verticalTemplates.ElementAt(new Random().Next(verticalTemplates.Count)));

        var horizontalTemplates = MockupTemplates.GetMockupTemplates()
            .Where(x => x.Type == (dto.IsVertical ? MockupTemplateType.HorizontalForVerticalFrame : MockupTemplateType.HorizontalForHorizontalFrame))
            .ToList();
        templates.Add(horizontalTemplates.ElementAt(new Random().Next(horizontalTemplates.Count)));

        // var templatesForAdditionalMockup = (dto.IsVertical ? verticalTemplates : horizontalTemplates);
        templates.Add(horizontalTemplates.ElementAt(new Random().Next(horizontalTemplates.Count)));
        
        // Use the provided template ids
        foreach (var templateId in dto.TemplateIds)
        {
            var template = MockupTemplates.GetMockupTemplates().FirstOrDefault(x => x.Id == templateId);
            if (template != null && templates.Any(x=>x.Type == template.Type))
            {
                var index = templates.FindIndex(x=>x.Type == template.Type) ;
                templates.RemoveAt(index);
                templates.Insert(index,template);
            }
        }
        
        return templates;
    }
}