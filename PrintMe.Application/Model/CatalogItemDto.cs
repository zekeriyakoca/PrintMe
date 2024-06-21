using PrintMe.Application.Entities;
using PrintMe.Application.Enums;

namespace PrintMe.Application.Model;

public class CatalogItemDto
{
    public int Id { get; set; }
    
    public string Name { get; set; }

    public string Motto { get; set; }

    public string Description { get; set; }
    
    public string Owner { get; set; }

    public decimal Price { get; set; }

    public Category Category { get; set; } = Category.None;

    public CatalogType CatalogType { get; set; } = CatalogType.Print;
    
    public CatalogTags? Tags { get; set; }

    // TODO : Implement based on the actual print size
    public List<PrintSize> Sizes => new List<PrintSize>() { PrintSize.Size13x18, PrintSize.Size21x30, PrintSize.Size30x40, PrintSize.Size40x50, PrintSize.Size50x50, PrintSize.Size70x100 };
    
    public int AvailableStock { get; set; }
    
    public int? SalePercentage { get; set; }
    
    public List<ImageDto> Images { get; set; }

    public string VariantType => "";
    public string Rating => "";
    public int NumberOfReviews => 0;

    public CatalogItemDto(CatalogItem item)
    {
        Id = item.Id;
        Name = item.Name;
        Motto = item.Motto;
        Description = item.Description;
        Price = item.Price * ((100 - item.SalePercentage.GetValueOrDefault(0)) / 100);
        Category = item.Category;
        CatalogType = item.CatalogType;
        Owner = item.Owner;
        Tags = item.Tags;
        AvailableStock = item.AvailableStock;
        SalePercentage = item.SalePercentage;
        Images = new List<ImageDto>()
        {
            new ImageDto(GetImageBaseUrl(item.PictureFileName, ".jpeg"), GetImageBaseUrl(item.PictureFileName, "-thumbnail.jpeg")),
            new ImageDto(GetImageBaseUrl(item.PictureFileName, "-mockup1.jpeg"), GetImageBaseUrl(item.PictureFileName, "-mockup1-thumbnail.jpeg")),
            new ImageDto(GetImageBaseUrl(item.PictureFileName, "-mockup2.jpeg"), GetImageBaseUrl(item.PictureFileName, "-mockup2-thumbnail.jpeg")),
            new ImageDto(GetImageBaseUrl(item.PictureFileName, "-mockup3.jpeg"), GetImageBaseUrl(item.PictureFileName, "-mockup3-thumbnail.jpeg"))
        };
    }
    
    private string GetImageBaseUrl(string imageId, string suffix)
    {
        return $"https://genstorageaccount3116.blob.core.windows.net/printme-processed-images/{imageId}/{imageId}{suffix}";
    }
}