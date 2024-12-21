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

public class CatalogController : BaseController
{
    private readonly ICatalogService _catalogService;
    private readonly IImageRepository _imageRepository;
    private readonly IQueueRepository _queueRepository;
    private readonly IConfiguration _configuration;

    public CatalogController(ILogger<CatalogController> logger, ICatalogService catalogService, IImageRepository imageRepository, IQueueRepository queueRepository,
        IConfiguration configuration) : base(logger)
    {
        _catalogService = catalogService;
        _imageRepository = imageRepository;
        _queueRepository = queueRepository;
        _configuration = configuration;
    }

    [HttpPost("custom-product/upload-image")]
    [RequestSizeLimit(52428800)] // 50 MB in bytes
    public async Task<ActionResult> UploadCustomProductImage([FromForm] UploadCustomProductImageRequestDto dto)
    {
        if (dto?.Image == null || dto.Image.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }

        if (dto.Image.ContentType != "image/jpeg" && dto.Image.ContentType != "image/png")
        {
            return BadRequest("Invalid file type.");
        }

        var imageId = Guid.NewGuid().ToString();
        await using var imageStream = dto.Image.OpenReadStream();
        // TODO : Introduce a Image service and hide the implementation details
        var customerImagesContainer = _configuration["AzureBlobStorageCustomProductImagesContainerName"];
        if (string.IsNullOrWhiteSpace(customerImagesContainer))
        {
            return StatusCode(500, "Server error!");
        }

        var url = await _imageRepository.UploadBlobAsync(imageId, customerImagesContainer, imageStream);
        return Ok(url);
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
    public async Task<ActionResult> SearchCatalogItems([FromBody] CatalogItemSearchRequestDto searchRequestDto)
    {
        var items = await _catalogService.SearchCatalogItems(searchRequestDto);
        return Ok(items);
    }

    [HttpGet("search")]
    public async Task<ActionResult> GetCatalogItemsFiltered([FromQuery] CatalogItemSearchRequestDto searchRequestDto)
    {
        var items = await _catalogService.SearchCatalogItems(searchRequestDto);
        return Ok(items);
    }


    [HttpPut("{id}")]
    [Authorize(Policy = "Admin")]
    public async Task<IActionResult> UpdateCatalogItem([FromRoute] int id, [FromBody] UpdateCatalogItemRequestDto catalogItem)
    {
        if (id != catalogItem.Id)
        {
            return BadRequest();
        }

        await _catalogService.UpdateCatalogItem(catalogItem);

        return NoContent();
    }

    [Obsolete($"Use {nameof(GenerateProductByImage)} instead.")]
    [HttpPost("upload-product-images")]
    public async Task<IActionResult> UploadImages([FromForm] UploadProductImagesRequestDto request)
    {
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

    [HttpPost("generate-product-by-image")]
    [RequestSizeLimit(104857600)] // 100 MB in bytes
    public async Task<IActionResult> GenerateProductByImage([FromForm] GenerateProductByImageDto dto)
    {
        foreach (var image in dto.Images)
        {
            var templates = RetrieveRandomTemplates(dto);
            var imageId = Guid.NewGuid().ToString();
            await using var imageStream = image.OpenReadStream();
            var url = await _imageRepository.UploadBlobAsync(imageId + ".jpeg", imageStream);

            var messageContent = new ImageProcessMessage(imageId, url, image.FileName, templates, dto.Tag);

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
            if (template != null && templates.Any(x => x.Type == template.Type))
            {
                var index = templates.FindIndex(x => x.Type == template.Type);
                templates.RemoveAt(index);
                templates.Insert(index, template);
            }
        }

        return templates;
    }
}