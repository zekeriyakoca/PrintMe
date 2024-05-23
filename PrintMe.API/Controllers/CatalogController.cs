using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrintMe.API.Services;
using PrintMe.Application.Entities;
using PrintMe.Application.Interfaces;
using PrintMe.Application.Model;

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
    
    // TODO : Do Search by multiple fields
    
    

    [HttpPut("{id}")]
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