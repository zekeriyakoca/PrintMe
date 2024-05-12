using PrintMe.Application.Entities;

namespace PrintMe.Application.Interfaces;

public interface ICatalogService
{
    Task<IEnumerable<CatalogItem>> GetCatalogItems();
    Task<CatalogItem> GetCatalogItem(int id);
    Task UpdateCatalogItem(CatalogItem catalogItem);
    Task CreateCatalogItem(CatalogItem catalogItem);
    Task DeleteCatalogItem(int id);
}