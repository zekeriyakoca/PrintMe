using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrintMe.Application.Constants;
using PrintMe.Application.Model;
using StackExchange.Redis;

namespace PrintMe.API.Controllers;

public class BootstrapController(ILogger<BootstrapController> logger) : BaseController(logger)
{
    [HttpGet("/health-check")]
    public IActionResult HealthCheck([FromServices] TelemetryClient telemetryClient)
    {
        telemetryClient.TrackEvent("HealthCheck has been called.");
        telemetryClient.Flush();
        return Ok("I'm alive!");
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
    
    [HttpGet("currentUser")]
    public ActionResult<UserDetails> GetCurrentUser()
    {
        return Ok(CurrentUser);
    }
}