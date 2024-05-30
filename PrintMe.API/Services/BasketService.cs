using PrintMe.Application.Interfaces;
using PrintMe.Application.Interfaces.Repositories;
using PrintMe.Application.Model;

namespace PrintMe.API.Services;

public class BasketService : IBasketService
{
    private readonly IBasketRepository _basketRepository;

    public BasketService(IBasketRepository basketRepository)
    {
        _basketRepository = basketRepository;
    }

    public Task<CustomerBasket?> GetBasketAsync(string customerId)
    {
        return _basketRepository.GetBasketAsync(customerId);
    }

    public Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket basket)
    {
        return _basketRepository.UpdateBasketAsync(basket);
    }

    public Task<bool> DeleteBasketAsync(string customerId)
    {
        return _basketRepository.DeleteBasketAsync(customerId);
    }
    
    public Task<bool> ValidateBasket(string customerId)
    {
        throw new NotImplementedException();
    }
}