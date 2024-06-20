using Microsoft.EntityFrameworkCore;
using PrintMe.Application.Entities;
using PrintMe.Application.Interfaces.Repositories;
using PrintMe.Infrastructure.Database;

namespace PrintMe.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationContext _context;

    public CustomerRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<bool> Exist(string id)
    {
        return await _context.Customers.AnyAsync(c => c.Id == id);
    }

    public async Task<Customer?> GetCustomer(string id)
    {
        return await _context.Customers.FindAsync(id);
    }

    public async Task UpdateCustomer(Customer customer)
    {
        var currentCustomer = await _context.Customers.FindAsync(customer.Id);
        if (currentCustomer == null)
        {
            throw new Exception("Customer not found.");
        }
        currentCustomer.Address = customer.Address;
        // currentCustomer.Email = customer.Email;
        currentCustomer.FullName = customer.FullName;
        currentCustomer.PhoneNumber = customer.PhoneNumber;
        currentCustomer.ProfilePictureUrl = customer.ProfilePictureUrl;
        currentCustomer.DateOfBirth = customer.DateOfBirth;
        currentCustomer.UpdatedAt = DateTime.Now;
        await _context.SaveChangesAsync();
    }

    public async Task CreateCustomer(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
    }
}