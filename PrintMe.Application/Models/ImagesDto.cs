namespace PrintMe.Application.Model;

public record ImagesDto(string Thumbnail, string ThumbnailAlternate, string image, string imageAlternate, IEnumerable<string> OtherImages)
{
    public IEnumerable<string> AllImages => new List<string> { image, imageAlternate }.Concat(OtherImages);
}