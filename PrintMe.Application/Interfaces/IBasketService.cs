using PrintMe.Application.Entities;
using PrintMe.Application.Model;

namespace PrintMe.Application.Interfaces;

public interface IBasketService
{
    Task<CustomerBasket?> GetBasketAsync(string customerId);
    Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket basket);
    Task<bool> DeleteBasketAsync(string id);
    Task<bool> ValidateBasket(string customerId);
}