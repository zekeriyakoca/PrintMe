using PrintMe.Application.Entities;
using PrintMe.Application.Model;

namespace PrintMe.Application.Interfaces;

public interface ICatalogService
{
    Task<PaginatedItems<CatalogItem>> GetCatalogItems(PaginationRequest paginationRequest);
    Task<IEnumerable<CatalogItem>> GetItemsByIds(int[] ids);
    Task<PaginatedItems<CatalogItemDto>> SearchCatalogItems(CatalogItemSearchRequest searchRequest);
    Task<CatalogItemDto?> GetCatalogItem(int id);
    Task<CatalogItemDto?> GetCustomCatalogItem();
    Task UpdateCatalogItem(UpdateCatalogItemRequest catalogItem);
    Task CreateCatalogItem(CatalogItem catalogItem);
    ValueTask DeleteCatalogItem(int id);
}