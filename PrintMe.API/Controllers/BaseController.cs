using Microsoft.AspNetCore.Mvc;

namespace PrintMe.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    public ILogger Logger { get; }

    public BaseController(ILogger logger)
    {
        Logger = logger;
    }
}