using Microsoft.EntityFrameworkCore;
using PrintMe.Application.Entities;
using PrintMe.Application.Interfaces.Repositories;
using PrintMe.Infrastructure.Database;

namespace PrintMe.Infrastructure.Repositories;

public class CatalogRepository : BaseRepository, ICatalogRepository
{
    private readonly ApplicationContext _context;

    public CatalogRepository(ApplicationContext context): base(context)
    {
        _context = context;
    }
    
    public IQueryable<CatalogItem> GetCatalogItemsLazily()
    {
        return _context.CatalogItems.AsNoTracking().AsQueryable();
    }
    public async Task<IEnumerable<CatalogItem>> GetCatalogItems()
    {
        return await _context.CatalogItems.AsNoTracking().ToListAsync();
    }

    public async Task<CatalogItem?> GetCatalogItem(int id)
    {
        return await _context.CatalogItems.FirstOrDefaultAsync(x=> x.Id == id);
    }
    
    public async Task<CatalogItem?> GetCatalogItemByName(string productName)
    {
        return await _context.CatalogItems.FirstOrDefaultAsync(x=> x.Name == productName);
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
