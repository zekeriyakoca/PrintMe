using PrintMe.Application.Entities;

namespace PrintMe.Application.Interfaces.Repositories;

public interface ICatalogRepository
{
    IQueryable<CatalogItem> GetCatalogItemsLazily();
    Task<IEnumerable<CatalogItem>> GetCatalogItems();
    Task<CatalogItem?> GetCatalogItem(int id);
    Task UpdateCatalogItem(CatalogItem catalogItem);
    Task CreateCatalogItem(CatalogItem catalogItem);
    void DeleteCatalogItem(int id);
}