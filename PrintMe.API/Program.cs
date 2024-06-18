using Azure.Storage.Queues;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Tokens;
using PrintMe.API;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel((context, options) => { options.Limits.MaxRequestBodySize = long.MaxValue; });

// Configure logging from appsettings.json
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddApplicationInsights();
builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));

//Configure services

builder.AddApplicationServices();

builder.Services.AddControllers();

// Configure FormOptions
builder.Services.Configure<Microsoft.AspNetCore.Http.Features.FormOptions>(options => { options.MultipartBodyLengthLimit = long.MaxValue; });

builder.Services.Configure<TelemetryConfiguration>((config) => { config.TelemetryChannel.DeveloperMode = true; });
builder.Services.AddApplicationInsightsTelemetry(builder.Configuration["ApplicationInsights:ConnectionString"]);

// Add services to the container.
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.Authority = "https://accounts.google.com";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = "https://accounts.google.com",
            ValidateAudience = true,
            ValidAudience = builder.Configuration["GoogleClientId"],
            ValidateLifetime = true
        };
    });

builder.Services.AddAuthorization(config =>
{
    config.AddPolicy("User", policyBuilder =>
        policyBuilder.RequireAuthenticatedUser());
    config.AddPolicy("Admin", policyBuilder =>
        policyBuilder.RequireRole("Admin"));
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();