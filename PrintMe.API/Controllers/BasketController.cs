using Microsoft.AspNetCore.Mvc;

namespace PrintMe.API.Controllers;


public class BasketController : BaseController
{
    public BasketController(ILogger<BasketController> logger) : base(logger)
    {
        
    }
    
    // [HttpGet]
    // public async Task<ActionResult<IEnumerable<BasketItem>>> GetBasketItems()
    // {
    //     return Ok();
    // }
    //
    // [HttpGet("{id}")]
    // public async Task<ActionResult<BasketItem>> GetBasketItem([FromRoute]int id)
    // {
    //     return Ok();
    // }
    //
    // [HttpPut("{id}")]
    // public async Task<IActionResult> UpdateBasketItem([FromRoute]int id, [FromBody]BasketItem basketItem)
    // {
    //     return NoContent();
    // }
    
}