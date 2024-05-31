using Microsoft.AspNetCore.Mvc;
using PrintMe.Application.Interfaces;
using PrintMe.Application.Model;

namespace PrintMe.API.Controllers;

public class BasketController : BaseController
{
    private readonly IBasketService _basketService;

    public BasketController(ILogger<BasketController> logger, IBasketService basketService) : base(logger)
    {
        _basketService = basketService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BasketItem>>> GetBasketItems()
    {
        var basket = await _basketService.GetOrCreateBasketAsync(CurrentUser.Id);
        return Ok(basket.Items);
    }

    [HttpPost("upsert")]
    public async Task<IActionResult> UpsertBasketItem([FromBody] BasketItem basketItem)
    {
        return Ok(await _basketService.UpsertBasketItemAsync(CurrentUser.Id, basketItem));
    }
}