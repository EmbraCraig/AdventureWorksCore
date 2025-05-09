namespace AdventureWorksCore.E2eTests.Shared.Dtos.Products;

internal record CreateProductDto
{
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
    public int? ProductModelId { get; init; }
    public int? ProductSubcategoryId { get; init; }
}
