using PrintMe.Application.Enums;

namespace PrintMe.Application.Model;

public record CatalogItemSearchRequestDto : PaginationRequestDto
{
    public string? SearchTerm { get; init; }
    public Category? Category { get; init; }
    public CatalogType? Type { get; init; }
    public PrintSize? Size { get; init; }
    public CatalogTags? Tags { get; init; }
    public int? PriceFrom { get; init; }
    public int? PriceTo { get; init; }
    public bool IsOnlyAvailableItems { get; init; } = true;
}