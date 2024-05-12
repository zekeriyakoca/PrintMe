using PrintMe.Application.Entities;
using PrintMe.Application.Interfaces;
using PrintMe.Application.Interfaces.Repositories;
using PrintMe.Infrastructure.Repositories;

namespace PrintMe.API.Services;

public class CatalogService : ICatalogService
{
    private readonly ICatalogRepository _catalogRepository;

    public CatalogService(ICatalogRepository catalogRepository)
    {
        _catalogRepository = catalogRepository;
    }

    public async Task<IEnumerable<CatalogItem>> GetCatalogItems()
    {
        return await _catalogRepository.GetCatalogItems();
    }

    public async Task<CatalogItem> GetCatalogItem(int id)
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

    public async Task DeleteCatalogItem(int id)
    {
        await _catalogRepository.DeleteCatalogItem(id);
    }
}