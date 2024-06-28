using System.Text.Json;
using PrintMe.Application.Entities;
using PrintMe.Application.Interfaces;
using PrintMe.Application.Interfaces.Repositories;
using PrintMe.Application.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using PrintMe.Application.DomainExceptions;

namespace PrintMe.API.Services;

public class CatalogService : ICatalogService
{
    private readonly ICatalogRepository _catalogRepository;
    private readonly IDistributedCache _cache;

    public CatalogService(ICatalogRepository catalogRepository, IDistributedCache cache)
    {
        _catalogRepository = catalogRepository;
        _cache = cache;
    }

    // TODO : Refactor here to return DTO
    public async Task<PaginatedItems<CatalogItem>> GetCatalogItems(PaginationRequest paginationRequest)
    {
        var totalItemsCount =  _catalogRepository.GetCatalogItemsLazily().Count();
        
        var items =  await _catalogRepository.GetCatalogItemsLazily()
            .OrderBy(c => c.Name)
            .Skip(paginationRequest.PageIndex * paginationRequest.PageSize)
            .Take(paginationRequest.PageSize)
            .ToListAsync();
        
        var result = new PaginatedItems<CatalogItem>(paginationRequest.PageIndex, paginationRequest.PageSize, totalItemsCount, items);
        
        return result;
    }
    
    // TODO : Refactor here to return DTO
    public async Task<IEnumerable<CatalogItem>> GetItemsByIds(int[] ids)
    {
        var items =  await _catalogRepository.GetCatalogItemsLazily()
            .Where(x => ids.Contains(x.Id))
            .ToListAsync();
        
        return items;
    }
    
    // TODO : Refactor here to return DTO
    public async Task<PaginatedItems<CatalogItemDto>> SearchCatalogItems(CatalogItemSearchRequest searchRequest)
    {
        var cacheKey = searchRequest.GetHashCode().ToString();
        var cachedResult = await _cache.GetStringAsync(cacheKey);
        if(!string.IsNullOrEmpty(cachedResult))
        {
            var cachedItems = JsonSerializer.Deserialize<PaginatedItems<CatalogItemDto>>(cachedResult);
            if (cachedItems != null)
            {
                return cachedItems;
            }
        }
        
        var result = await SearchCatalogItems_DoWork(searchRequest);
        await _cache.SetStringAsync(cacheKey, JsonSerializer.Serialize(result), new DistributedCacheEntryOptions() { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)});

        return result;
    }
    
    private async Task<PaginatedItems<CatalogItemDto>> SearchCatalogItems_DoWork(CatalogItemSearchRequest searchRequest)
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
            query = query.Where(x => (searchRequest.Category.Value & x.Category) > 0);
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
            .Select(x=> CatalogItemDto.FromCatalogItem(x))
            .ToListAsync();

        return new PaginatedItems<CatalogItemDto>(searchRequest.PageIndex, searchRequest.PageSize, count, items);
    }

    public async Task<CatalogItemDto?> GetCatalogItem(int id)
    {
        return CatalogItemDto.FromCatalogItem(await _catalogRepository.GetCatalogItem(id) ?? throw new GenericNotFoundException("Catalog item not found."));
    }

    public async Task UpdateCatalogItem(UpdateCatalogItemRequest catalogItem)
    {
        var entity = await _catalogRepository.GetCatalogItem(catalogItem.Id);
        if(entity == null)
        {
            throw new Exception("Catalog item not found.");
        }
        entity.Name = catalogItem.Name;
        entity.Description = catalogItem.Description;
        entity.Price = catalogItem.Price;
        entity.Category = catalogItem.Category;
        entity.CatalogType = catalogItem.CatalogType;
        entity.Tags = catalogItem.Tags;
        await _catalogRepository.SaveChangesAsync();
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