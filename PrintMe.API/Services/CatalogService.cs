using Microsoft.AspNetCore.Mvc;
using PrintMe.Application.Entities;
using PrintMe.Application.Interfaces;
using PrintMe.Application.Interfaces.Repositories;
using PrintMe.Application.Model;
using PrintMe.Infrastructure.Repositories;
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

    public async Task<CatalogItem?> GetCatalogItem(int id)
    {
        return await _catalogRepository.GetCatalogItem(id);
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