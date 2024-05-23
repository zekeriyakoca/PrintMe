using PrintMe.Application.Entities;
using PrintMe.Application.Model;

namespace PrintMe.Application.Interfaces;

public interface ICatalogService
{
    Task<PaginatedItems<CatalogItem>> GetCatalogItems(PaginationRequest paginationRequest);
    Task<IEnumerable<CatalogItem>> GetItemsByIds(int[] ids);
    Task<PaginatedItems<CatalogItem>> SearchCatalogItems(CatalogItemSearchRequest searchRequest);
    Task<CatalogItem?> GetCatalogItem(int id);
    Task UpdateCatalogItem(CatalogItem catalogItem);
    Task CreateCatalogItem(CatalogItem catalogItem);
    ValueTask DeleteCatalogItem(int id);
}