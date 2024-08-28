using PrintMe.Application.Entities;

namespace PrintMe.Application.Interfaces.Repositories;

public interface ICatalogRepository : IBaseRepository
{
    IQueryable<CatalogItem> GetCatalogItemsLazily();
    Task<IEnumerable<CatalogItem>> GetCatalogItems();
    Task<CatalogItem?> GetCatalogItem(int id);
    Task<CatalogItem?> GetCatalogItemByName(string productName);
    Task UpdateCatalogItem(CatalogItem catalogItem);
}