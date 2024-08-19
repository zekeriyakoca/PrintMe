using PrintMe.Application.Interfaces.Repositories;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;
using PrintMe.Application.Model;

namespace PrintMe.Infrastructure.Repositories;

public class ImageRepository : IImageRepository
{
    private readonly BlobServiceClient _blobServiceClient;
    private readonly string _containerName;

    public ImageRepository(IConfiguration configuration)
    {
        _blobServiceClient = new BlobServiceClient(configuration["AzureBlobStorageConnectionString"]);
        _containerName = configuration["AzureBlobStorageContainerName"];
    }

    public async Task UploadImageAsync(string folderName, Stream imageStream, Stream? imageAlternateStream, Stream? thumbnailStream, Stream? thumbnailAlternateStream, IEnumerable<Stream> otherImageStreams)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);

        await UploadBlobAsync(containerClient, $"{folderName}/image.jpeg", imageStream);
        if (imageAlternateStream != null)
        {      
            await UploadBlobAsync(containerClient, $"{folderName}/imageAlternate.jpeg", imageAlternateStream);
        }
        if (thumbnailStream != null)
        {      
            await UploadBlobAsync(containerClient, $"{folderName}/thumbnail.jpeg", thumbnailStream);
        }
        if (thumbnailAlternateStream != null)
        {      
            await UploadBlobAsync(containerClient, $"{folderName}/thumbnailAlternate.jpeg", thumbnailAlternateStream);
        }


        int index = 1;
        foreach (var otherImageStream in otherImageStreams)
        {
            await UploadBlobAsync(containerClient, $"{folderName}/otherImage{index}.jpeg", otherImageStream);
            index++;
        }
    }

    public async Task<string> UploadBlobAsync(string blobName, Stream stream, string contentType = "image/jpeg")
    => await UploadBlobAsync(blobName, _containerName, stream, contentType);
    
    public async Task<string> UploadBlobAsync(string blobName, string containerName, Stream stream, string contentType = "image/jpeg")
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        return await UploadBlobAsync(containerClient, blobName, stream, contentType);
    }
    private async Task<string> UploadBlobAsync(BlobContainerClient containerClient, string blobName, Stream stream, string contentType = "image/jpeg")
    {
        var blobClient = containerClient.GetBlobClient(blobName);
        var response = await blobClient.UploadAsync(stream, new BlobHttpHeaders { ContentType = contentType });
        // await blobClient.SetAccessTierAsync(AccessTier.Hot);
        return blobClient.Uri.AbsoluteUri;
    }

    public async Task<bool> DoesFolderExistAsync(string folderName)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
        await foreach (BlobItem blobItem in containerClient.GetBlobsAsync(prefix: folderName))
        {
            if (blobItem.Name.StartsWith(folderName))
            {
                return true;
            }
        }
        return false;
    }
}