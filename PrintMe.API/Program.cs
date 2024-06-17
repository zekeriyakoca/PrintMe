using Azure.Storage.Queues;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using PrintMe.API;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel((context, options) =>
{
    options.Limits.MaxRequestBodySize = long.MaxValue; 
});

// Configure logging from appsettings.json
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddApplicationInsights();
builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));

//Configure services

builder.AddApplicationServices();

builder.Services.AddControllers();

// Configure FormOptions
builder.Services.Configure<Microsoft.AspNetCore.Http.Features.FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = long.MaxValue; 
});

builder.Services.Configure<TelemetryConfiguration>((config) =>
{
    config.TelemetryChannel.DeveloperMode = true;
});
builder.Services.AddApplicationInsightsTelemetry(builder.Configuration["ApplicationInsights:ConnectionString"]);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(options =>
    {
        builder.Configuration.Bind("AzureAd", options);
        options.TokenValidationParameters.NameClaimType = "name";
    }, options => { builder.Configuration.Bind("AzureAd", options); });

builder.Services.AddAuthorization(config =>
{
    config.AddPolicy("User", policyBuilder =>
        policyBuilder.Requirements.Add(new ScopeAuthorizationRequirement() { RequiredScopesConfigurationKey = $"AzureAd:UserScopes" }));
    config.AddPolicy("Admin", policyBuilder =>
        policyBuilder.Requirements.Add(new ScopeAuthorizationRequirement() { RequiredScopesConfigurationKey = $"AzureAd:AdminScopes" }));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("RedisConnection");
    options.InstanceName = "PrintMe_";
});

builder.Services.AddSingleton<IConnectionMultiplexer>(
    ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("RedisConnection") ?? "localhost"));

builder.Services.AddSession(opt => 
{ 
    opt.Cookie.HttpOnly = true; 
    opt.Cookie.IsEssential = true; 
    opt.Cookie.SameSite = SameSiteMode.None;
    opt.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    opt.IdleTimeout = TimeSpan.FromDays(1);
}); 

builder.Services.AddSingleton(sp => new QueueClient(builder.Configuration["AzureBlobStorageConnectionString"], "images-to-process"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AnyOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000", "https://lemon-hill-0c96b3e03.5.azurestaticapps.net")
                .AllowAnyHeader()
                .AllowCredentials()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Application is starting up.");

var telemetryClient = app.Services.GetRequiredService<TelemetryClient>();
telemetryClient.TrackEvent("TrackEvent: Application is tarting up");
telemetryClient.Flush();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AnyOrigin");

app.UseHttpsRedirection();

app.UseSession();

app.MapGet("/", (HttpContext context) =>
{
    var telemetryClient = context.RequestServices.GetRequiredService<TelemetryClient>();
    telemetryClient.TrackEvent("Application Started");
    telemetryClient.Flush();

    return Results.Ok("Event Tracked");
});

app.MapControllers();

app.Run();
