namespace PrintMe.Application.Interfaces.Repositories;

public interface IBaseRepository
{
    public Task SaveChangesAsync();
}