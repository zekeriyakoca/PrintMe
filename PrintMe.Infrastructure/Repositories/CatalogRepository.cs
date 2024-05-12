using Microsoft.EntityFrameworkCore;
using PrintMe.Application.Entities;
using PrintMe.Application.Interfaces.Repositories;
using PrintMe.Infrastructure.Database;

namespace PrintMe.Infrastructure.Repositories;

public class CatalogRepository : ICatalogRepository
{
    private readonly ApplicationContext _context;

    public CatalogRepository(ApplicationContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<CatalogItem>> GetCatalogItems()
    {
        return await _context.CatalogItems.ToListAsync();
    }

    public async Task<CatalogItem?> GetCatalogItem(int id)
    {
        return await _context.CatalogItems.FirstOrDefaultAsync(x=> x.Id == id);
    }

    public Task UpdateCatalogItem(CatalogItem catalogItem)
    {
        throw new NotImplementedException();
    }

    public Task CreateCatalogItem(CatalogItem catalogItem)
    {
        _context.CatalogItems.Add(catalogItem);
        return _context.SaveChangesAsync();
    }

    public void DeleteCatalogItem(int id)
    {
        _context.CatalogItems.Remove(new CatalogItem { Id = id });
    }
}
