using Azure.Storage.Blobs;
using PrintMe.Application.Model;

namespace PrintMe.Application.Interfaces.Repositories;

public interface IImageRepository
{
    Task UploadImageAsync(string folderName, Stream imageStream, Stream? imageAlternateStream, Stream? thumbnailStream, Stream? thumbnailAlternateStream, IEnumerable<Stream> otherImageStreams);
    Task<bool> DoesFolderExistAsync(string folderName);
    Task<string> UploadBlobAsync(string blobName, Stream stream, string contentType = "image/jpeg");
    Task<string> UploadBlobAsync(string blobName, string containerName, Stream stream, string contentType = "image/jpeg");
}