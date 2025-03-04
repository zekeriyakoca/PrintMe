using PrintMe.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using PrintMe.API.Services;
using PrintMe.Application.Interfaces;
using PrintMe.Application.Interfaces.Repositories;
using PrintMe.Infrastructure.Repositories;

namespace PrintMe.API;

public static class ServiceCollectionExtensions
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ApplicationContext>(options =>
             options.UseNpgsql(builder.Configuration.GetConnectionString("SqlDefaultConnection"),  b => b.MigrationsAssembly("PrintMe.API")));

        builder.Services.AddTransient<ICatalogService, CatalogService>();
        builder.Services.AddTransient<IOrderService, OrderService>();
        builder.Services.AddTransient<IBasketService, BasketService>();

        builder.Services.AddTransient<ICatalogRepository, CatalogRepository>();
        builder.Services.AddTransient<IBasketRepository, BasketRepository>();
        builder.Services.AddSingleton<IImageRepository, ImageRepository>();
        builder.Services.AddSingleton<IQueueRepository, QueueRepository>();
        builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
    }
}
