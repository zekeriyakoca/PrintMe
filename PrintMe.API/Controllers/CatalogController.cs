using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrintMe.API.Services;
using PrintMe.Application.Entities;
using PrintMe.Application.Interfaces;
using PrintMe.Application.Interfaces.Repositories;
using PrintMe.Application.Model;

namespace PrintMe.API.Controllers;

// [Authorize]
public class CatalogController : BaseController
{
    private readonly ICatalogService _catalogService;
    private readonly IImageRepository _imageRepository;

    public CatalogController(ILogger<CatalogController> logger, ICatalogService catalogService, IImageRepository imageRepository) : base(logger)
    {
        _catalogService = catalogService;
        _imageRepository = imageRepository;
    }
    
    [HttpGet]
    [Authorize(Policy = "Admin")]
    public async Task<ActionResult> GetCatalogItems([FromQuery]PaginationRequest paginationRequest)
    {
        var items = await _catalogService.GetCatalogItems(paginationRequest);
        return Ok(items);
    }
    
    [HttpPost("items-by-ids")]
    public async Task<ActionResult> GetCatalogItems([FromBody]int[] ids)
    {
        if (!ids.Any())
        {
            return BadRequest("No id provided.");
        }

        var items = await _catalogService.GetItemsByIds(ids);
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CatalogItem>> GetCatalogItem([FromRoute]int id)
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
    
    [HttpPost("search")]
    public async Task<ActionResult> SearchCatalogItems([FromBody]CatalogItemSearchRequest searchRequest)
    {
        var items = await _catalogService.SearchCatalogItems(searchRequest);
        return Ok(items);
    }
    
    [HttpGet("search")]
    public async Task<ActionResult> GetCatalogItemsFiltered([FromQuery]CatalogItemSearchRequest searchRequest)
    {
        var items = await _catalogService.SearchCatalogItems(searchRequest);
        return Ok(items);
    }
    

    [HttpPut("{id}")]
    [Authorize(Policy = "Admin")]
    public async Task<IActionResult> UpdateCatalogItem([FromRoute]int id, [FromBody]CatalogItem catalogItem)
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
    
    [HttpPost("upload-product-images")]
    public async Task<IActionResult> UploadImages([FromForm] UploadProductImagesRequest request)
    {
        // if (await _imageRepository.DoesFolderExistAsync(request.FolderName))
        // {
        //     return BadRequest("Folder already exists.");
        // }
    
        using var imageStream = request.Image.OpenReadStream();
        using var imageAlternateStream = request.ImageAlternate?.OpenReadStream();
        using var thumbnailStream = request.Thumbnail?.OpenReadStream();
        using var thumbnailAlternateStream = request.ThumbnailAlternate?.OpenReadStream();
    
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
}