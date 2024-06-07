using PrintMe.Application.Model;

namespace PrintMe.Application.Interfaces.Repositories;

public interface IQueueRepository
{
    public Task SendImageProcessMessageAsync(ImageProcessMessage message);
    
}