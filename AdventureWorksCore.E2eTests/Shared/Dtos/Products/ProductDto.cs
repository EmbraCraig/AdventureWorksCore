namespace AdventureWorksCore.E2eTests.Shared.Dtos.Products;

public record ProductDto
{
    public int? Id { get; init; }
    public string? Name { get; init; }
    public string? ProductNumber { get; init; }
    public bool? MakeFlag { get; init; }
    public bool? FinishedGoodsFlag { get; init; }
    public string? Color { get; init; }
    public short? SafetyStockLevel { get; init; }
    public short? ReorderPoint { get; init; }
    public decimal? StandardCost { get; init; }
    public decimal? ListPrice { get; init; }
    public string? Size { get; init; }
    public string? SizeUnitMeasureCode { get; init; }
    public string? WeightUnitMeasureCode { get; init; }
    public decimal? Weight { get; init; }
    public int? DaysToManufacture { get; init; }
    public string? ProductLine { get; init; }
    public string? Class { get; init; }
    public string? Style { get; init; }
    public DateTime? SellStartDate { get; init; }
    public DateTime? SellEndDate { get; init; }
    public DateTime? DiscontinuedDate { get; init; }
    public DateTime? ModifiedDate { get; init; }
    public ProductModelDto? ProductModel { get; init; }
    public ProductSubcategoryDto? ProductSubcategory { get; init; }
    public ICollection<ProductReviewDto>? ProductReviews { get; init; }
    public ICollection<ProductPhotoDto>? ProductPhotos { get; init; }
}

public record ProductModelDto
{
    public int? Id { get; init; }
    public string? Name { get; init; }
    public string? CatalogDescription { get; init; }
    public string? Instructions { get; init; }
    public DateTime? ModifiedDate { get; init; }
}

public record ProductSubcategoryDto
{
    public int? Id { get; init; }
    public string? Name { get; init; }
    public int? ProductCategoryId { get; init; }
    public string? ProductCategoryName { get; init; }
    public DateTime? ModifiedDate { get; init; }
}

public record ProductReviewDto
{
    public int? Id { get; init; }
    public string? ReviewerName { get; init; }
    public DateTime? ReviewDate { get; init; }
    public string? EmailAddress { get; init; }
    public int? Rating { get; init; }
    public string? Comments { get; init; }
    public DateTime? ModifiedDate { get; init; }
}

public record ProductPhotoDto
{
    public int? Id { get; init; }
    public string? ThumbnailPhotoFileName { get; init; }
    public string? LargePhotoFileName { get; init; }
    public DateTime? ModifiedDate { get; init; }
}
