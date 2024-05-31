using System.Text.Json;
using Microsoft.Extensions.Logging;
using PrintMe.Application.Interfaces.Repositories;
using PrintMe.Application.Model;
using StackExchange.Redis;

namespace PrintMe.Infrastructure.Repositories;

public class BasketRepository : IBasketRepository
{
    private readonly ILogger<BasketRepository> _logger;
    private readonly IDatabase _redis;

    public BasketRepository(IConnectionMultiplexer muxer, ILogger<BasketRepository> logger)
    {
        _logger = logger;
        _redis = muxer?.GetDatabase() ?? throw new ArgumentNullException(nameof(muxer));
    }

    public async Task<CustomerBasket?> GetBasketAsync(string customerId)
    {
        var data = await _redis.StringGetLeaseAsync(GetBasketKey(customerId));
        if (data is null || data.Length == 0)
        {
            return null;
        }

        return JsonSerializer.Deserialize<CustomerBasket?>(data.Span);
    }
    
    public Task<CustomerBasket?> CreateEmptyBasketAsync(string customerId)
    {
        var newBasket = new CustomerBasket(customerId);
        return UpdateBasketAsync(newBasket);
    }

    public async Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket basket)
    {
        var json = JsonSerializer.SerializeToUtf8Bytes(basket);
        var created = await _redis.StringSetAsync(GetBasketKey(basket.BuyerId), json);

        if (!created)
        {
            _logger.LogInformation("Problem occurred persisting the item.");
            return null;
        }

        _logger.LogInformation("Basket item persisted successfully.");
        return await GetBasketAsync(basket.BuyerId);
    }

    public Task<bool> DeleteBasketAsync(string id)
    {
        return _redis.KeyDeleteAsync(GetBasketKey(id));
    }

    private string GetBasketKey(string customerId)
    {
        if (String.IsNullOrWhiteSpace(customerId)) throw new ArgumentNullException(nameof(customerId));

        return String.Format(BasketPrefix, customerId);
    }

    private const string BasketPrefix = "CustomerBasket_{0}";
}