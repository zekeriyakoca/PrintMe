using PrintMe.Application.Enums;

namespace PrintMe.Application.Model;

public class ImageProcessMessage
{
    public string ImageId { get; set; }
    public string ImageUrl { get; set; }
    
    public string ImageDescription { get; set; }
    public CatalogTags? Tag { get; set; }
    public List<MockupTemplate> MockupTemplates { get; set; } = new();
}