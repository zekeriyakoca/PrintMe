using System.Text.Json.Serialization;
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
    public List<PrintSize> Sizes => new List<PrintSize>() { PrintSize.Size13x18, PrintSize.Size21x30, PrintSize.Size30x40, PrintSize.Size40x50, PrintSize.Size50x70, PrintSize.Size61x91 };
    
    public int AvailableStock { get; set; }
    
    public int? SalePercentage { get; set; }
    
    public List<ImageDto> Images { get; set; }

    public string VariantType => "";
    public string Rating => "";
    public int NumberOfReviews => 0;

    // Parameterless constructor needed for deserialization
    public CatalogItemDto() {}

    [JsonConstructor]
    public CatalogItemDto(int id, string name, string motto, string description, string owner, decimal price, Category category, CatalogType catalogType, CatalogTags? tags, int availableStock, int? salePercentage, List<ImageDto> images)
    {
        Id = id;
        Name = name;
        Motto = motto;
        Description = description;
        Owner = owner;
        Price = price;
        Category = category;
        CatalogType = catalogType;
        Tags = tags;
        AvailableStock = availableStock;
        SalePercentage = salePercentage;
        Images = images ?? new List<ImageDto>();
    }

    // Example method to convert from CatalogItem to CatalogItemDto
    public static CatalogItemDto FromCatalogItem(CatalogItem item)
    {
        return new CatalogItemDto(
            item.Id,
            item.Name,
            item.Motto,
            item.Description,
            item.Owner,
            item.Price * ((100 - item.SalePercentage.GetValueOrDefault(0)) / 100),
            item.Category,
            item.CatalogType,
            item.Tags,
            item.AvailableStock,
            item.SalePercentage,
            new List<ImageDto>
            {
                new ImageDto(GetImageBaseUrl(item.PictureFileName, ".jpeg"), GetImageBaseUrl(item.PictureFileName, "-thumbnail.jpeg")),
                new ImageDto(GetImageBaseUrl(item.PictureFileName, "-mockup1.jpeg"), GetImageBaseUrl(item.PictureFileName, "-mockup1-thumbnail.jpeg")),
                new ImageDto(GetImageBaseUrl(item.PictureFileName, "-mockup2.jpeg"), GetImageBaseUrl(item.PictureFileName, "-mockup2-thumbnail.jpeg")),
                new ImageDto(GetImageBaseUrl(item.PictureFileName, "-mockup3.jpeg"), GetImageBaseUrl(item.PictureFileName, "-mockup3-thumbnail.jpeg"))
            }
        );
    }
    
    private static string GetImageBaseUrl(string imageId, string suffix)
    {
        return $"https://genstorageaccount3116.blob.core.windows.net/printme-processed-images/{imageId}/{imageId}{suffix}";
    }
}