using Microsoft.EntityFrameworkCore;
using PrintMe.Application.Entities;
using PrintMe.Application.Interfaces;
using PrintMe.Application.Model;

namespace PrintMe.API.Services;

public class OrderService : IOrderService
{
    private readonly DbContext _context;

    public OrderService(DbContext context)
    {
        _context = context;
    }
    
    public async Task CreateDraftOrderAsync(CreateOrderRequest dto)
    {
        throw new NotImplementedException();
    }
}