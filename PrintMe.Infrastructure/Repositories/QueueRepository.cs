using System.Text.Json;
using Azure.Storage.Queues;
using PrintMe.Application.Interfaces.Repositories;
using PrintMe.Application.Model;

namespace PrintMe.Infrastructure.Repositories;

public class QueueRepository : IQueueRepository
{
    private readonly QueueClient _queueClient;

    public QueueRepository(QueueClient queueClient)
    {
        _queueClient = queueClient;
    }

    public async Task SendImageProcessMessageAsync(ImageProcessMessage message)
    {
        var messageJson = JsonSerializer.Serialize(message);
        await _queueClient.SendMessageAsync(messageJson);
    }
}