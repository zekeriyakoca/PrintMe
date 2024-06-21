using System.ComponentModel.DataAnnotations;
using PrintMe.Application.Enums;

namespace PrintMe.Application.Model;

public class UpdateCatalogItemRequest
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    [MaxLength(1000)]
    public string Description { get; set; }
    [Range(0,1000)]
    public decimal Price { get; set; }

    public Category Category { get; set; } = Category.None;

    public CatalogType CatalogType { get; set; } = CatalogType.Print;
    
    public CatalogTags? Tags { get; set; }
}