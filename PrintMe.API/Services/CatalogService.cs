using PrintMe.Application.Entities;
using PrintMe.Application.Interfaces;
using PrintMe.Application.Interfaces.Repositories;
using PrintMe.Application.Model;
using Microsoft.EntityFrameworkCore;

namespace PrintMe.API.Services;

public class CatalogService : ICatalogService
{
    private readonly ICatalogRepository _catalogRepository;

    public CatalogService(ICatalogRepository catalogRepository)
    {
        _catalogRepository = catalogRepository;
    }

    public async Task<PaginatedItems<CatalogItem>> GetCatalogItems(PaginationRequest paginationRequest)
    {
        var totalItems =  _catalogRepository.GetCatalogItemsLazily().Count();
        
        var items =  await _catalogRepository.GetCatalogItemsLazily()
            .OrderBy(c => c.Name)
            .Skip(paginationRequest.PageIndex * paginationRequest.PageSize)
            .Take(paginationRequest.PageSize)
            .ToListAsync();
        
        var result = new PaginatedItems<CatalogItem>(paginationRequest.PageIndex, paginationRequest.PageSize, totalItems, items);
        
        return result;
    }
    
    public async Task<IEnumerable<CatalogItem>> GetItemsByIds(int[] ids)
    {
        var items =  await _catalogRepository.GetCatalogItemsLazily()
            .Where(x => ids.Contains(x.Id))
            .ToListAsync();
        
        return items;
    }
    public async Task<PaginatedItems<CatalogItemDto>> SearchCatalogItems(CatalogItemSearchRequest searchRequest)
    {
        var query = _catalogRepository.GetCatalogItemsLazily();
        
        if (!string.IsNullOrEmpty(searchRequest.SearchTerm))
        {
            // TODO : Implement free text search and, then, search utilizing AI
            query = query.Where(x => x.Name.Contains(searchRequest.SearchTerm) || x.Description.Contains(searchRequest.SearchTerm) || x.Owner.Contains(searchRequest.SearchTerm) || x.SearchParameters.Contains(searchRequest.SearchTerm));
        }
        
        if (searchRequest.PriceFrom.HasValue)
        {
            query = query.Where(x => x.Price >= searchRequest.PriceFrom);
        }
        
        if (searchRequest.PriceTo.HasValue)
        {
            query = query.Where(x => x.Price <= searchRequest.PriceTo);
        }
        
        if (searchRequest.IsOnlyAvailableItems)
        {
            query = query.Where(x => x.AvailableStock > 0);
        }
        
        if (searchRequest.Tags.HasValue)
        {
            query = query.Where(x => x.Tags.HasValue && x.Tags.Value.HasFlag(searchRequest.Tags.Value));
        }
        
        if (searchRequest.Type.HasValue)
        {
            query = query.Where(x => x.CatalogType.HasFlag(searchRequest.Type.Value));
        }
        
        if (searchRequest.Category.HasValue)
        {
            query = query.Where(x => x.Category.HasFlag(searchRequest.Category.Value));
        }
        
        if (searchRequest.Size.HasValue)
        {
            query = query.Where(x => x.Size == searchRequest.Size);
        }

        var count = await query.LongCountAsync();
        var items = await query
            .OrderBy(x=>x.Id)
            .Skip(searchRequest.PageIndex * searchRequest.PageSize)
            .Take(searchRequest.PageSize)
            .Select(x=>new CatalogItemDto(x))
            .ToListAsync();

        return new PaginatedItems<CatalogItemDto>(searchRequest.PageIndex, searchRequest.PageSize, count, items);
    }

    public async Task<CatalogItemDto?> GetCatalogItem(int id)
    {
        return new CatalogItemDto(await _catalogRepository.GetCatalogItem(id));
    }

    public async Task UpdateCatalogItem(CatalogItem catalogItem)
    {
        await _catalogRepository.UpdateCatalogItem(catalogItem);
    }

    public async Task CreateCatalogItem(CatalogItem catalogItem)
    {
        await _catalogRepository.CreateCatalogItem(catalogItem);
    }

    public ValueTask DeleteCatalogItem(int id)
    {
        _catalogRepository.DeleteCatalogItem(id);
        return ValueTask.CompletedTask;
    }
}