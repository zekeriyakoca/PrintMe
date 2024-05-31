using PrintMe.Application.DomainExceptions;
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

    public async Task<CustomerBasket> GetOrCreateBasketAsync(string customerId)
    {
        var basket =  await _basketRepository.GetBasketAsync(customerId);
        if (basket == null)
        {
            return await _basketRepository.CreateEmptyBasketAsync(customerId) ?? throw new Exception("Error happened while creating a basket!");
        }

        return basket;
    }

    public Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket basket)
    {
        return _basketRepository.UpdateBasketAsync(basket);
    }
    
    public async Task<CustomerBasket?> UpsertBasketItemAsync(string customerId, BasketItem item)
    {
        var basket = await _basketRepository.GetBasketAsync(customerId);

        if (basket == null)
        {
            throw new GenericNotFoundException("Basket could not be found!");
        }

        var itemToUpdate = basket.Items.FirstOrDefault(i => i.Id == item.Id);
        if (itemToUpdate != null)
        {
            itemToUpdate.Update(item);
        }
        else
        {
            basket.Items.Add(item);
        }

        return await _basketRepository.UpdateBasketAsync(basket);
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