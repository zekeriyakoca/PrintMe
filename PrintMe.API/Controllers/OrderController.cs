using Microsoft.AspNetCore.Mvc;
using PrintMe.Application.Interfaces;
using PrintMe.Application.Model;

namespace PrintMe.API.Controllers;


public class OrderController : BaseController
{
    private readonly IOrderService _orderService;

    public OrderController(ILogger<OrderController> logger, IOrderService orderService) : base(logger)
    {
        _orderService = orderService;
    }

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
    public async Task<ActionResult> CreateOrderDraftAsync([FromBody]CreateDraftOrderRequest dto)
    {
        throw new NotImplementedException();
    }
    
    [HttpPost]
    public async Task<object> CreateOrderAsync([FromBody]CreateOrderRequest dto)
    {
        throw new NotImplementedException();
    }

}