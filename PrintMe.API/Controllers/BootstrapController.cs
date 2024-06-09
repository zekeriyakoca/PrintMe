using Microsoft.AspNetCore.Mvc;
using PrintMe.Application.Constants;
using PrintMe.Application.Model;

namespace PrintMe.API.Controllers;

public class BootstrapController : BaseController
{

    public BootstrapController(ILogger<BootstrapController> logger) : base(logger)
    {
    }

    [HttpGet("frames")]
    public async Task<ActionResult<IEnumerable<FrameDto>>> GetFrameOptions()
    {
        return Ok(BootstrapConstants.FRAMES);
    }
    [HttpGet("sizes")]
    public async Task<ActionResult<IEnumerable<SizeDto>>> GetSizeOptions()
    {
        return Ok(BootstrapConstants.SIZES);
    }
}