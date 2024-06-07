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
        _blobServiceClient = new BlobServiceClient(configuration["AzureBlobStorage:ConnectionString"]);
        _containerName = configuration["AzureBlobStorage:ContainerName"];
    }

    public async Task UploadImageAsync(string folderName, Stream imageStream, Stream? imageAlternateStream, Stream? thumbnailStream, Stream? thumbnailAlternateStream, IEnumerable<Stream> otherImageStreams)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);

        await UploadBlobAsync(containerClient, $"{folderName}/image.jpg", imageStream);
        if (imageAlternateStream != null)
        {      
            await UploadBlobAsync(containerClient, $"{folderName}/imageAlternate.jpg", imageAlternateStream);
        }
        if (thumbnailStream != null)
        {      
            await UploadBlobAsync(containerClient, $"{folderName}/thumbnail.jpg", thumbnailStream);
        }
        if (thumbnailAlternateStream != null)
        {      
            await UploadBlobAsync(containerClient, $"{folderName}/thumbnailAlternate.jpg", thumbnailAlternateStream);
        }


        int index = 1;
        foreach (var otherImageStream in otherImageStreams)
        {
            await UploadBlobAsync(containerClient, $"{folderName}/otherImage{index}.jpg", otherImageStream);
            index++;
        }
    }

    public async Task<ImagesDto> GetImageUrlsAsync(string folderName)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
        string thumbnailUrl = containerClient.GetBlobClient($"{folderName}/thumbnail.jpg").Uri.AbsoluteUri;
        string thumbnailAlternateUrl = containerClient.GetBlobClient($"{folderName}/thumbnailAlternate.jpg").Uri.AbsoluteUri;
        string imageUrl = containerClient.GetBlobClient($"{folderName}/image.jpg").Uri.AbsoluteUri;
        string imageAlternateUrl = containerClient.GetBlobClient($"{folderName}/imageAlternate.jpg").Uri.AbsoluteUri;

        List<string> otherImages = new List<string>();
        await foreach (var blobItem in containerClient.GetBlobsAsync(prefix: $"{folderName}/otherImage"))
        {
            otherImages.Add(containerClient.GetBlobClient(blobItem.Name).Uri.AbsoluteUri);
        }

        return new ImagesDto(thumbnailUrl, thumbnailAlternateUrl, imageUrl, imageAlternateUrl, otherImages);
    }

    public async Task<string> UploadBlobAsync(string blobName, Stream stream, string contentType = "image/jpeg")
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
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