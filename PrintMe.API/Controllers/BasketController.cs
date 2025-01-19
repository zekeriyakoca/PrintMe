using Microsoft.AspNetCore.Mvc;
using PrintMe.Application.Interfaces;
using PrintMe.Application.Model;

namespace PrintMe.API.Controllers;

public class BasketController(ILogger<BasketController> logger, IBasketService basketService) : BaseController(logger)
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BasketItem>>> GetBasketItems()
    {
        var basket = await basketService.GetOrCreateBasketAsync(CurrentUser.Id);
        return Ok(basket.Items);
    }

    [HttpPost("upsert-item")]
    public async Task<IActionResult> UpsertBasketItem([FromBody] BasketItem basketItem)
    {
        return Ok(await basketService.UpsertBasketItemAsync(CurrentUser.Id, basketItem));
    }
    
    [HttpPut]
    public async Task<IActionResult> SetBasket([FromBody] List<BasketItem> basketItems)
    {
        return Ok(await basketService.UpdateBasketAsync(new CustomerBasket(CurrentUser.Id){Items = basketItems}));
    }
}