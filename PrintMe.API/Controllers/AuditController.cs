using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using PrintMe.Application.Model;

namespace PrintMe.API.Controllers;

public class AuditController(ILogger<AuditController> logger) : BaseController(logger)
{
    [HttpPost("")]
    public IActionResult TrackEvent([FromServices] TelemetryClient telemetryClient, [FromBody] AuditEvent auditEvent)
    {
        telemetryClient.TrackEvent(auditEvent.Name, new Dictionary<string, string>
        {
            { "message", auditEvent.Message }, { "UserId", CurrentUser.Id }, { "UserIPAddress", HttpContext.Connection.RemoteIpAddress?.ToString() ?? "Unknown" },
            { "UserAgent", Request.Headers["User-Agent"].ToString() },
            { "RequestPath", HttpContext.Request.Path },
            { "SessionId", HttpContext.Session.Id }
        });
        telemetryClient.Flush();
        return Ok();
    }
}