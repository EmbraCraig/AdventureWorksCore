using AdventureWorksCore.Models;

namespace AdventureWorksCore.Application.Products.Dtos;

/// <summary>
/// Simplified Product DTO to demonstrate Include vs Projection patterns
/// Contains 5 properties from different child entities to show SQL complexity differences
/// </summary>
public record ProductSummaryDto
{
    public int Id { get; init; }
    public string Name { get; init; } = null!;
    public string ProductNumber { get; init; } = null!;
    public decimal StandardCost { get; init; }
    public decimal ListPrice { get; init; }
    
    // Properties from different child entities to demonstrate Include vs Projection
    public string? ProductModelName { get; init; }           // From ProductModel
    public string? SubcategoryName { get; init; }            // From ProductSubcategory
    public string? CategoryName { get; init; }               // From ProductSubcategory.ProductCategory
    public string? SizeUnitMeasureName { get; init; }        // From SizeUnitMeasureCodeNavigation (UnitMeasure)
    public string? WeightUnitMeasureName { get; init; }      // From WeightUnitMeasureCodeNavigation (UnitMeasure)

    /// <summary>
    /// Maps from Product entity loaded with Include statements
    /// This approach loads all related entities into memory first, then maps
    /// </summary>
    public static ProductSummaryDto MapFromEntity(Product entity)
    {
        return new()
        {
            Id = entity.ProductId,
            Name = entity.Name,
            ProductNumber = entity.ProductNumber,
            StandardCost = entity.StandardCost,
            ListPrice = entity.ListPrice,
            ProductModelName = entity.ProductModel?.Name,
            SubcategoryName = entity.ProductSubcategory?.Name,
            CategoryName = entity.ProductSubcategory?.ProductCategory?.Name,
            SizeUnitMeasureName = entity.SizeUnitMeasureCodeNavigation?.Name,
            WeightUnitMeasureName = entity.WeightUnitMeasureCodeNavigation?.Name
        };
    }
}