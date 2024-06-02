namespace PrintMe.Application.Enums;

[Flags]
public enum Category : long
{
    None = 0,

    // Nature Subcategories
    NaturePrints = 1 << 0,
    Botanical = 1 << 1,
    Animals = 1 << 2,
    SpaceAndAstronomy = 1 << 3,
    MapsAndCities = 1 << 4,
    Nature = NaturePrints | Botanical | Animals | SpaceAndAstronomy | MapsAndCities,

    // Vintage & Retro Subcategories
    RetroAndVintage = 1 << 15,
    BlackAndWhite = 1 << 16,
    GoldAndSilver = 1 << 17,
    HistoricalPrints = 1 << 18,
    ClassicPosters = 1 << 19,
    VintageAndRetro = RetroAndVintage | BlackAndWhite | GoldAndSilver | HistoricalPrints | ClassicPosters,

    // Art Styles Subcategories
    Illustrations = 1 << 30,
    Photographs = 1L << 31,
    ArtPrints = 1L << 32,
    TextPosters = 1L << 33,
    Graphical = 1L << 34,
    ArtStyles = Illustrations | Photographs | ArtPrints | TextPosters | Graphical,

    // Famous Painters Subcategories
    FamousPainters = 1L << 45,
    IconicPhotos = 1L << 46,
    StudioCollections = 1L << 47,
    ModernArtists = 1L << 48,
    AbstractArt = 1L << 49,
    FamousPaintersCategory = FamousPainters | IconicPhotos | StudioCollections | ModernArtists | AbstractArt,
}