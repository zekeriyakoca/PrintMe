using Microsoft.AspNetCore.Mvc;

namespace PrintMe.API.Controllers;


public class OrderController : BaseController
{
    public OrderController(ILogger<OrderController> logger) : base(logger)
    {
        
    }

}