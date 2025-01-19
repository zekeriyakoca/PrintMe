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
    public OrderByEnum OrderBy { get; init; } = OrderByEnum.Order;
    public bool HasQuery => !string.IsNullOrEmpty(SearchTerm) || Category.HasValue || Type.HasValue || Size.HasValue || Tags.HasValue;
}

public enum OrderByEnum
{
    Order,
    PriceAsc,
    PriceDesc,
    DateAsc,
    DateDesc,
    MostPopular,
    BestRating
}