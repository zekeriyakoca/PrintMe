using PrintMe.Application.Entities;
using PrintMe.Application.Enums;

namespace PrintMe.Application.Model;

public class CatalogItemDto
{
    public int Id { get; set; }
    
    public string Name { get; set; }

    public string Description { get; set; }
    
    public string Owner { get; set; }

    public decimal Price { get; set; }

    // TODO : Remove when image object implemented
    public string Image { get; }
    
    public string ImagesDto { get; set; }

    public string Link => "catalog/" + this.Id;

    public Category Category { get; set; } = Category.None;

    public CatalogType CatalogType { get; set; } = CatalogType.Default;
    
    public CatalogTags? Tags { get; set; }

    public List<PrintSize> Sizes => new List<PrintSize>() { PrintSize.Size13x18, PrintSize.Size21x30, PrintSize.Size30x40, PrintSize.Size40x50, PrintSize.Size50x50, PrintSize.Size70x100 };
    
    public List<PrintSize> AllOfSizes => new List<PrintSize>() { PrintSize.Size13x18, PrintSize.Size21x30, PrintSize.Size30x40, PrintSize.Size40x50, PrintSize.Size50x50, PrintSize.Size70x100 };

    public int AvailableStock { get; set; }
    
    public int? SalePercentage { get; set; }

    public string VariantType => "";
    public string Rating => "";
    public int NumberOfReviews => 0;

    public CatalogItemDto(CatalogItem item)
    {
        Id = item.Id;
        Name = item.Name;
        Description = item.Description;
        Price = Convert.ToInt32(item.Price * ((100 - item.SalePercentage.GetValueOrDefault(0)) / 100));
        Image = "https://images.pexels.com/photos/5843990/pexels-photo-5843990.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load";
        Category = item.Category;
        CatalogType = item.CatalogType;
        Owner = item.Owner;
        Tags = item.Tags;
        AvailableStock = item.AvailableStock;
        SalePercentage = item.SalePercentage;
    }
}