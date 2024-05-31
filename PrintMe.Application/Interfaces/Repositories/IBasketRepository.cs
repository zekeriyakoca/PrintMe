using PrintMe.Application.Model;

namespace PrintMe.Application.Interfaces.Repositories;

public interface IBasketRepository
{
    
    Task<CustomerBasket?> GetBasketAsync(string customerId);
    Task<CustomerBasket?> CreateEmptyBasketAsync(string customerId);
    Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket basket);
    Task<bool> DeleteBasketAsync(string id);
}