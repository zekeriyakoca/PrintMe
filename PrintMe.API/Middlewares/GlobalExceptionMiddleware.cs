using System.Net;
using System.Text.Json;
using PrintMe.Application.DomainExceptions;

namespace PrintMe.API.Middlewares;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger logger;
    public GlobalExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
    {
        _next = next;
        logger = loggerFactory.CreateLogger<GlobalExceptionMiddleware>();
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (BussinessException ex)
        {
            logger.LogError(ex, ex.BussinessMessage);
            await HandleExceptionAsync(httpContext, ex);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unhandled exception");
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        (context.Response.StatusCode, var message) = exception switch
        {
            GenericNotFoundException => ((int)HttpStatusCode.BadRequest, "Resource not found!"),
            CatalogDomainException => ((int)HttpStatusCode.BadRequest, "Bad Request! Please check your request and try again."),
            BussinessException => ((int)HttpStatusCode.BadRequest, "Bad Request! Please check your request and try again."),
            _ => ((int)HttpStatusCode.InternalServerError, "Internal Server Error!"),
        };

        return context.Response.WriteAsync(new ErrorDetails()
        {
            StatusCode = context.Response.StatusCode,
            Message = message
        }.ToString());
    }
}
public class ErrorDetails
{
    public int StatusCode { get; set; }
    public string Message { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}