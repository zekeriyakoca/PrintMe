using Microsoft.AspNetCore.Http;

namespace PrintMe.Application.Model;

public class UploadProductImagesRequestDto
{
    public string FolderName { get; set; }
    public IFormFile Image { get; set; }
    public IFormFile? ImageAlternate { get; set; }
    public IFormFile? Thumbnail { get; set; }
    public IFormFile? ThumbnailAlternate { get; set; }
    public List<IFormFile>? OtherImages { get; set; } = new List<IFormFile>();
}