namespace AdventureWorksCore.E2eTests.Shared.Dtos.Products;

internal record UpdateProductDto
{
    public int Id { get; init; }

    public string Name { get; init; } = "";
}
