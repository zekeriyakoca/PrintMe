using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrintMe.API.Services;
using PrintMe.Application.Entities;
using PrintMe.Application.Interfaces;

namespace PrintMe.API.Controllers;

// [Authorize]
public class CatalogController : BaseController
{
    private readonly ICatalogService _catalogService;

    public CatalogController(ILogger<CatalogController> logger, ICatalogService catalogService) : base(logger)
    {
        _catalogService = catalogService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CatalogItem>>> GetCatalogItems()
    {
        return Ok(await _catalogService.GetCatalogItems());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CatalogItem>> GetCatalogItem(int id)
    {
        var catalogItem = await _catalogService.GetCatalogItem(id);

        if (catalogItem == null)
        {
            return NotFound();
        }

        return Ok(catalogItem);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCatalogItem(int id, CatalogItem catalogItem)
    {
        if (id != catalogItem.Id)
        {
            return BadRequest();
        }

        await _catalogService.UpdateCatalogItem(catalogItem);

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<CatalogItem>> CreateCatalogItem(CatalogItem catalogItem)
    {
        await _catalogService.CreateCatalogItem(catalogItem);

        return CreatedAtAction(nameof(GetCatalogItem), new { id = catalogItem.Id }, catalogItem);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCatalogItem(int id)
    {
        await _catalogService.DeleteCatalogItem(id);

        return NoContent();
    }
    
}