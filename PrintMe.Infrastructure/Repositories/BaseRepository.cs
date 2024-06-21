using PrintMe.Infrastructure.Database;
using PrintMe.Application.Interfaces.Repositories;

namespace PrintMe.Infrastructure.Repositories;

public class BaseRepository : IBaseRepository
{
    protected readonly ApplicationContext Context;

    public BaseRepository(ApplicationContext context)
    {
        Context = context;
    }
    
    public async Task SaveChangesAsync()
    {
        await Context.SaveChangesAsync();
    }
}