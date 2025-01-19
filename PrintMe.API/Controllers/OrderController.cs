using Microsoft.AspNetCore.Mvc;
using PrintMe.Application.Interfaces;
using PrintMe.Application.Model;

namespace PrintMe.API.Controllers;


public class OrderController(ILogger<OrderController> logger, IOrderService orderService) : BaseController(logger)
{
    private readonly IOrderService _orderService = orderService;

    [HttpGet("{orderId}")]
    public async Task<ActionResult<OrderSummary>> GetOrder([FromRoute] int orderId)
    {
        throw new NotImplementedException();
    }
    
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderSummary>>> GetOrdersByUserAsync([FromQuery] int userId)
    {
        throw new NotImplementedException();
    }
    
    [HttpPost("draft")]
    public async Task<ActionResult> CreateOrderDraftAsync([FromBody]CreateDraftOrderRequestDto dto)
    {
        throw new NotImplementedException();
    }
    
    [HttpPost]
    public async Task<object> CreateOrderAsync([FromBody]CreateOrderRequestDto dto)
    {
        throw new NotImplementedException();
    }

}