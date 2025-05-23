using AdventureWorksCore.Models;

namespace AdventureWorksCore.Application.Projects.Dtos;

public record ProductDto
{
    public int Id { get; init; }
    public string Name { get; init; } = null!;
    public string ProductNumber { get; init; } = null!;
    public bool MakeFlag { get; init; }
    public bool FinishedGoodsFlag { get; init; }
    public string? Color { get; init; }
    public short SafetyStockLevel { get; init; }
    public short ReorderPoint { get; init; }
    public decimal StandardCost { get; init; }
    public decimal ListPrice { get; init; }
    public string? Size { get; init; }
    public string? SizeUnitMeasureCode { get; init; }
    public string? WeightUnitMeasureCode { get; init; }
    public decimal? Weight { get; init; }
    public int DaysToManufacture { get; init; }
    public string? ProductLine { get; init; }
    public string? Class { get; init; }
    public string? Style { get; init; }
    public DateTime SellStartDate { get; init; }
    public DateTime? SellEndDate { get; init; }
    public DateTime? DiscontinuedDate { get; init; }
    public DateTime ModifiedDate { get; init; }
    public ProductModelDto? ProductModel { get; init; }
    public ProductSubcategoryDto? ProductSubcategory { get; init; }
    public ICollection<ProductReviewDto> ProductReviews { get; init; } = [];
    public ICollection<ProductPhotoDto> ProductPhotos { get; init; } = [];

    public static ProductDto MapFromEntity(Product entity)
    {
        return new()
        {
            Id = entity.ProductId,
            Name = entity.Name,
            ProductNumber = entity.ProductNumber,
            MakeFlag = entity.MakeFlag,
            FinishedGoodsFlag = entity.FinishedGoodsFlag,
            Color = entity.Color,
            SafetyStockLevel = entity.SafetyStockLevel,
            ReorderPoint = entity.ReorderPoint,
            StandardCost = entity.StandardCost,
            ListPrice = entity.ListPrice,
            Size = entity.Size,
            SizeUnitMeasureCode = entity.SizeUnitMeasureCode?.Trim(),
            WeightUnitMeasureCode = entity.WeightUnitMeasureCode?.Trim(),
            Weight = entity.Weight,
            DaysToManufacture = entity.DaysToManufacture,
            ProductLine = entity.ProductLine?.Trim(),
            Class = entity.Class?.Trim(),
            Style = entity.Style?.Trim(),
            SellStartDate = entity.SellStartDate,
            SellEndDate = entity.SellEndDate,
            DiscontinuedDate = entity.DiscontinuedDate,
            ModifiedDate = entity.ModifiedDate,
            ProductModel = entity.ProductModel != null ? ProductModelDto.MapFromEntity(entity.ProductModel) : null,
            ProductSubcategory = entity.ProductSubcategory != null ? ProductSubcategoryDto.MapFromEntity(entity.ProductSubcategory) : null,
            ProductReviews = [.. entity.ProductReviews.Select(ProductReviewDto.MapFromEntity)],
            ProductPhotos = [.. entity.ProductProductPhotos.Select(ppp => ProductPhotoDto.MapFromEntity(ppp.ProductPhoto))]
        };
    }
}

public record ProductModelDto
{
    public int Id { get; init; }
    public string Name { get; init; } = null!;
    public string? CatalogDescription { get; init; }
    public string? Instructions { get; init; }
    public DateTime ModifiedDate { get; init; }

    public static ProductModelDto MapFromEntity(ProductModel entity)
    {
        return new()
        {
            Id = entity.ProductModelId,
            Name = entity.Name,
            CatalogDescription = entity.CatalogDescription,
            Instructions = entity.Instructions,
            ModifiedDate = entity.ModifiedDate
        };
    }
}

public record ProductSubcategoryDto
{
    public int Id { get; init; }
    public string Name { get; init; } = null!;
    public int ProductCategoryId { get; init; }
    public string ProductCategoryName { get; init; } = null!;
    public DateTime ModifiedDate { get; init; }

    public static ProductSubcategoryDto MapFromEntity(ProductSubcategory entity)
    {
        return new()
        {
            Id = entity.ProductSubcategoryId,
            Name = entity.Name,
            ProductCategoryId = entity.ProductCategoryId,
            ProductCategoryName = entity.ProductCategory.Name,
            ModifiedDate = entity.ModifiedDate
        };
    }
}

public record ProductReviewDto
{
    public int Id { get; init; }
    public string ReviewerName { get; init; } = null!;
    public DateTime ReviewDate { get; init; }
    public string EmailAddress { get; init; } = null!;
    public int Rating { get; init; }
    public string? Comments { get; init; }
    public DateTime ModifiedDate { get; init; }

    public static ProductReviewDto MapFromEntity(ProductReview entity)
    {
        return new()
        {
            Id = entity.ProductReviewId,
            ReviewerName = entity.ReviewerName,
            ReviewDate = entity.ReviewDate,
            EmailAddress = entity.EmailAddress,
            Rating = entity.Rating,
            Comments = entity.Comments,
            ModifiedDate = entity.ModifiedDate
        };
    }
}

public record ProductPhotoDto
{
    public int Id { get; init; }
    public string? ThumbnailPhotoFileName { get; init; }
    public string? LargePhotoFileName { get; init; }
    public DateTime ModifiedDate { get; init; }

    public static ProductPhotoDto MapFromEntity(ProductPhoto entity)
    {
        return new()
        {
            Id = entity.ProductPhotoId,
            ThumbnailPhotoFileName = entity.ThumbnailPhotoFileName,
            LargePhotoFileName = entity.LargePhotoFileName,
            ModifiedDate = entity.ModifiedDate
        };
    }
}

public record BillOfMaterialDto
{
    public int BillOfMaterialsId { get; init; }
    public int? ProductAssemblyId { get; init; }
    public int ComponentId { get; init; }
    public DateTime StartDate { get; init; }
    public DateTime? EndDate { get; init; }
    public string UnitMeasureCode { get; init; } = null!;
    public string? UnitMeasureName { get; init; } = null!;
    public short Bomlevel { get; init; }
    public decimal PerAssemblyQty { get; init; }
    public DateTime ModifiedDate { get; init; }
    public SubProductDto Component { get; init; } = null!;
    public SubProductDto? ProductAssembly { get; init; }
}

public record SubProductDto
{
    public int Id { get; init; }
    public string Name { get; init; } = null!;
}


