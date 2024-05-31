using PrintMe.Application.Entities;
using PrintMe.Application.Model;

namespace PrintMe.Application.Interfaces;

public interface IBasketService
{
    Task<CustomerBasket> GetOrCreateBasketAsync(string customerId);
    Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket basket);
    Task<CustomerBasket?> UpsertBasketItemAsync(string customerId, BasketItem item);
    Task<bool> DeleteBasketAsync(string id);
    Task<bool> ValidateBasket(string customerId);
}