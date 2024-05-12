using PrintMe.Application.Entities;
using PrintMe.Application.Interfaces.Repositories;

namespace PrintMe.Infrastructure.Repositories;

public class CatalogRepository : ICatalogRepository
{
    public Task<IEnumerable<CatalogItem>> GetCatalogItems()
    {
        throw new NotImplementedException();
    }

    public Task<CatalogItem> GetCatalogItem(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateCatalogItem(CatalogItem catalogItem)
    {
        throw new NotImplementedException();
    }

    public Task CreateCatalogItem(CatalogItem catalogItem)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCatalogItem(int id)
    {
        throw new NotImplementedException();
    }
}
