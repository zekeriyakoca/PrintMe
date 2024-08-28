using PrintMe.Application.Entities;
using PrintMe.Application.Model;

namespace PrintMe.Application.Interfaces;

public interface ICatalogService
{
    Task<PaginatedItems<CatalogItemDto>> GetCatalogItems(PaginationRequestDto paginationRequestDto);
    Task<IEnumerable<CatalogItemDto>> GetItemsByIds(int[] ids);
    Task<PaginatedItems<CatalogItemDto>> SearchCatalogItems(CatalogItemSearchRequestDto searchRequestDto);
    Task<CatalogItemDto?> GetCatalogItem(int id);
    Task<CatalogItemDto?> GetCustomCatalogItem();
    Task UpdateCatalogItem(UpdateCatalogItemRequestDto catalogItem);
}