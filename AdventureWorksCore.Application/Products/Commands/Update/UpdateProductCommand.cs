using AdventureWorksCore.Application.Common.AppRequests;
using AdventureWorksCore.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace AdventureWorksCore.Application.Projects.Commands.Update;

public record UpdateProductCommand
{
    [JsonIgnore]
    public int ProductId { get; init; }

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
    public int? ProductModelId { get; init; }
    public int? ProductSubcategoryId { get; init; }
    public DateTime? SellEndDate { get; init; }
    public DateTime? DiscontinuedDate { get; init; }
}

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IDateTimeService _dateTimeService;

    public UpdateProductCommandHandler(IApplicationDbContext dbContext, IDateTimeService dateTimeService)
    {
        _dbContext = dbContext;
        _dateTimeService = dateTimeService;
    }

    public async Task<AppResponse> Handle(
        UpdateProductCommand command,
        CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Products
            .FirstOrDefaultAsync(_ => _.ProductId == command.ProductId, cancellationToken);

        if (entity == null)
        {
            return new(404);
        }

        entity.Name = command.Name;
        entity.ProductNumber = command.ProductNumber;
        entity.MakeFlag = command.MakeFlag;
        entity.FinishedGoodsFlag = command.FinishedGoodsFlag;
        entity.Color = command.Color;
        entity.SafetyStockLevel = command.SafetyStockLevel;
        entity.ReorderPoint = command.ReorderPoint;
        entity.StandardCost = command.StandardCost;
        entity.ListPrice = command.ListPrice;
        entity.Size = command.Size;
        entity.SizeUnitMeasureCode = command.SizeUnitMeasureCode;
        entity.WeightUnitMeasureCode = command.WeightUnitMeasureCode;
        entity.Weight = command.Weight;
        entity.DaysToManufacture = command.DaysToManufacture;
        entity.ProductLine = command.ProductLine;
        entity.Class = command.Class;
        entity.Style = command.Style;
        entity.ProductModelId = command.ProductModelId;
        entity.ProductSubcategoryId = command.ProductSubcategoryId;
        entity.SellEndDate = command.SellEndDate;
        entity.DiscontinuedDate = command.DiscontinuedDate;
        entity.ModifiedDate = _dateTimeService.Now;

        await _dbContext.SaveChangesAsync(cancellationToken);

        return new(200);
    }
}
