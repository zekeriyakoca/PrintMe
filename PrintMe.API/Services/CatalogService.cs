using System.Text.Json;
using PrintMe.Application.Entities;
using PrintMe.Application.Interfaces;
using PrintMe.Application.Interfaces.Repositories;
using PrintMe.Application.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using PrintMe.Application.Constants;
using PrintMe.Application.DomainExceptions;

namespace PrintMe.API.Services;

public class CatalogService(ICatalogRepository catalogRepository, IDistributedCache cache) : ICatalogService
{
    public async Task<PaginatedItems<CatalogItemDto>> GetCatalogItems(PaginationRequestDto paginationRequestDto)
    {
        var totalItemsCount =  catalogRepository.GetCatalogItemsLazily().Count();
        
        var items = await catalogRepository.GetCatalogItemsLazily()
            .OrderBy(c => c.Name)
            .Where(x => x.Name != ApplicationConstants.CUSTOM_PRODUCT_NAME)
            .Skip(paginationRequestDto.PageIndex * paginationRequestDto.PageSize)
            .Take(paginationRequestDto.PageSize)
            .Select(x=> CatalogItemDto.FromCatalogItem(x))
            .ToListAsync();
        
        var result = new PaginatedItems<CatalogItemDto>(paginationRequestDto.PageIndex, paginationRequestDto.PageSize, totalItemsCount, items);
        
        return result;
    }
    
    public async Task<IEnumerable<CatalogItemDto>> GetItemsByIds(int[] ids)
    {
        var items =  await catalogRepository.GetCatalogItemsLazily()
            .Select(x=> CatalogItemDto.FromCatalogItem(x))
            .Where(x=> ids.Contains(x.Id) && x.Name != ApplicationConstants.CUSTOM_PRODUCT_NAME)
            .ToListAsync();
        
        return items;
    }
    
    public async Task<PaginatedItems<CatalogItemDto>> SearchCatalogItems(CatalogItemSearchRequestDto searchRequestDto)
    {
        var cacheKey = searchRequestDto.GetHashCode().ToString();
        var cachedResult = await cache.GetStringAsync(cacheKey);
        if(!string.IsNullOrEmpty(cachedResult))
        {
            var cachedItems = JsonSerializer.Deserialize<PaginatedItems<CatalogItemDto>>(cachedResult);
            if (cachedItems != null)
            {
                return cachedItems;
            }
        }
        
        var result = await SearchCatalogItems_DoWork(searchRequestDto);
        await cache.SetStringAsync(cacheKey, JsonSerializer.Serialize(result), new DistributedCacheEntryOptions() { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)});

        return result;
    }
    
    private async Task<PaginatedItems<CatalogItemDto>> SearchCatalogItems_DoWork(CatalogItemSearchRequestDto searchRequestDto)
    {
        var query = catalogRepository.GetCatalogItemsLazily();
        
        if (!string.IsNullOrEmpty(searchRequestDto.SearchTerm))
        {
            // TODO : Implement free text search and, then, search utilizing AI
            query = query.Where(x => x.Name.Contains(searchRequestDto.SearchTerm) || x.Description.Contains(searchRequestDto.SearchTerm) || x.Motto.Contains(searchRequestDto.SearchTerm) || x.Owner.Contains(searchRequestDto.SearchTerm) || x.SearchParameters.Contains(searchRequestDto.SearchTerm));
        }
        
        if (searchRequestDto.PriceFrom.HasValue)
        {
            query = query.Where(x => x.Price >= searchRequestDto.PriceFrom);
        }
        
        if (searchRequestDto.PriceTo.HasValue)
        {
            query = query.Where(x => x.Price <= searchRequestDto.PriceTo);
        }
        
        if (searchRequestDto.IsOnlyAvailableItems)
        {
            query = query.Where(x => x.AvailableStock > 0);
        }
        
        if (searchRequestDto.Tags.HasValue)
        {
            query = query.Where(x => x.Tags.HasValue && x.Tags.Value.HasFlag(searchRequestDto.Tags.Value));
        }
        
        if (searchRequestDto.Type.HasValue)
        {
            query = query.Where(x => x.CatalogType.HasFlag(searchRequestDto.Type.Value));
        }
        
        if (searchRequestDto.Category.HasValue)
        {
            query = query.Where(x => (searchRequestDto.Category.Value & x.Category) > 0);
        }
        
        if (searchRequestDto.Size.HasValue)
        {
            query = query.Where(x => x.Size == searchRequestDto.Size);
        }

        query = searchRequestDto.OrderBy switch
        {
            OrderByEnum.Order => query.OrderByDescending(x => x.ItemOrder),
            OrderByEnum.PriceAsc => query.OrderBy(x => x.Price),
            OrderByEnum.PriceDesc => query.OrderByDescending(x => x.Price),
            OrderByEnum.DateAsc => query.OrderBy(x => x.Id),
            OrderByEnum.DateDesc => query.OrderByDescending(x => x.Id),
            OrderByEnum.MostPopular => query.OrderBy(x => x.Id),
            _ => query
        };
        var count = await query.LongCountAsync();
        var items = await query
            .Where(x => x.Name != ApplicationConstants.CUSTOM_PRODUCT_NAME)
            .Skip(searchRequestDto.PageIndex * searchRequestDto.PageSize)
            .Take(searchRequestDto.PageSize)
            .Select(x=> CatalogItemDto.FromCatalogItem(x))
            .ToListAsync();

        return new PaginatedItems<CatalogItemDto>(searchRequestDto.PageIndex, searchRequestDto.PageSize, count, items);
    }

    public async Task<CatalogItemDto?> GetCatalogItem(int id)
    {
        return CatalogItemDto.FromCatalogItem(await catalogRepository.GetCatalogItem(id) ?? throw new GenericNotFoundException("Catalog item not found."));
    }
    
    public Task DeleteCatalogItem(int id)
    {
        return catalogRepository.DeleteCatalogItem(id);
    }
    
    // TODO : Refactor here
    public async Task<CatalogItemDto?> GetCustomCatalogItem()
    {
        return CatalogItemDto.FromCatalogItem(await catalogRepository.GetCatalogItemByName(ApplicationConstants.CUSTOM_PRODUCT_NAME) ?? throw new GenericNotFoundException("Custom product not found."));
    }

    public async Task UpdateCatalogItem(UpdateCatalogItemRequestDto catalogItem)
    {
        var entity = await catalogRepository.GetCatalogItem(catalogItem.Id);
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
        entity.ItemOrder = catalogItem.ItemOrder;
        await catalogRepository.SaveChangesAsync();
    }
}