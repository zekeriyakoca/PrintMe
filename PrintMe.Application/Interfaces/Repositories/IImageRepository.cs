using PrintMe.Application.Model;

namespace PrintMe.Application.Interfaces.Repositories;

public interface IImageRepository
{
    Task<ImagesDto> GetImageUrlsAsync(string folderName);
    Task UploadImageAsync(string folderName, Stream imageStream, Stream? imageAlternateStream, Stream? thumbnailStream, Stream? thumbnailAlternateStream, IEnumerable<Stream> otherImageStreams);
    Task<bool> DoesFolderExistAsync(string folderName);
}