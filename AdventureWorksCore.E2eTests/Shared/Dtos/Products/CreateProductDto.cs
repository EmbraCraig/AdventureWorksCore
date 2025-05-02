namespace AdventureWorksCore.E2eTests.Shared.Dtos.Products;

internal record CreateProductDto
{
    public string Name { get; init; } = "";
    public string ProductNumber { get; init; } = "";
}
