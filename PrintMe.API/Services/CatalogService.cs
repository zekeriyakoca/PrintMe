using PrintMe.Application.Entities;
using PrintMe.Application.Interfaces;
using PrintMe.Application.Interfaces.Repositories;
using PrintMe.Application.Model;
using Microsoft.EntityFrameworkCore;
using PrintMe.Application.DomainExceptions;

namespace PrintMe.API.Services;

public class CatalogService : ICatalogService
{
    private readonly ICatalogRepository _catalogRepository;

    public CatalogService(ICatalogRepository catalogRepository)
    {
        _catalogRepository = catalogRepository;
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
            .Select(x=>new CatalogItemDto(x))
            .ToListAsync();

        return new PaginatedItems<CatalogItemDto>(searchRequest.PageIndex, searchRequest.PageSize, count, items);
    }

    public async Task<CatalogItemDto?> GetCatalogItem(int id)
    {
        return new CatalogItemDto(await _catalogRepository.GetCatalogItem(id) ?? throw new GenericNotFoundException("Catalog item not found."));
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