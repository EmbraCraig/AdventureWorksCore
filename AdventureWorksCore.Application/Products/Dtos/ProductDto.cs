using AdventureWorksCore.Models;

namespace AdventureWorksCore.Application.Projects.Dtos;

public record ProductDto
{
    public int Id { get; init; }

    public string Name { get; init; } = "";

    public static ProductDto MapFromEntity(Product entity)
    {
        return new()
        {
            Id = entity.ProductId,
            Name = entity.Name,
        };
    }
}
