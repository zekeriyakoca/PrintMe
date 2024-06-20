using PrintMe.Application.Entities;

namespace PrintMe.Application.Interfaces.Repositories;

public interface ICustomerRepository
{
    Task<bool> Exist(string id);
    Task<Customer?> GetCustomer(string id);
    Task UpdateCustomer(Customer customer);
    Task CreateCustomer(Customer customer);
}


