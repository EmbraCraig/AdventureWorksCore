namespace AdventureWorksCore.E2eTests.Shared.Dtos.Products;

public record ProductDto
{
    public int Id { get; init; }

    public string Name { get; init; } = "";
}
