using Microsoft.EntityFrameworkCore;
using PrintMe.Application.Entities;
using PrintMe.Application.Interfaces;
using PrintMe.Application.Model;
using PrintMe.Infrastructure.Database;

namespace PrintMe.API.Services;

public class OrderService : IOrderService
{
    private readonly ApplicationContext _context;

    public OrderService(ApplicationContext context)
    {
        _context = context;
    }
    
    public async Task CreateDraftOrderAsync(CreateOrderRequestDto dto)
    {
        throw new NotImplementedException();
    }
}