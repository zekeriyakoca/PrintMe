using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using PrintMe.Application.Model;

namespace PrintMe.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    protected ILogger Logger { get; }

    protected UserDetails CurrentUser {
        get
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var email = User.FindFirstValue(ClaimTypes.Email);
            var name = User.FindFirstValue("name");

            if (userId != null && name != null)
            {    
                return new UserDetails(userId, name, email, User.FindFirstValue("picture"), User.IsInRole("Admin")); 
            }

            var guestInString = HttpContext.Session.GetString("GuestUser");
            if (!String.IsNullOrWhiteSpace(guestInString) && TryDeserialize(guestInString, out UserDetails? guest))
            {
                return guest;
            }

            var guestUser = new UserDetails(Guid.NewGuid().ToString(), "Guest", String.Empty, "https://genstorageaccount3116.blob.core.windows.net/printme-images/profile.svg");
            HttpContext.Session.SetString("GuestUser", JsonSerializer.Serialize(guestUser));
            return guestUser;

        }
    }

    private bool TryDeserialize<T>(string valueInString, out T? value)
    {
        
        value = default;
        try
        {
            value = JsonSerializer.Deserialize<T>(valueInString);
        }
        catch
        {
            return false;
        }

        return true;
    }

    public BaseController(ILogger logger)
    {
        Logger = logger;
    }
}