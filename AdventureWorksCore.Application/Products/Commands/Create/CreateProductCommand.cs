using AdventureWorksCore.Application.Common.AppRequests;
using AdventureWorksCore.Application.Common.Interfaces;
using AdventureWorksCore.Models;

namespace AdventureWorksCore.Application.Products.Commands.Create;

public class CreateProductCommand
{
    public string Name { get; init; } = null!;
    public string ProductNumber { get; init; } = null!;
    public bool MakeFlag { get; init; } = true;
    public bool FinishedGoodsFlag { get; init; } = true;
    public string? Color { get; init; }
    public short SafetyStockLevel { get; init; } = 1;
    public short ReorderPoint { get; init; } = 1;
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
}

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IDateTimeService _dateTimeService;

    public CreateProductCommandHandler(IApplicationDbContext dbContext, IDateTimeService dateTimeService)
    {
        _dbContext = dbContext;
        _dateTimeService = dateTimeService;
    }

    public async Task<AppResponse<int>> Handle(
        CreateProductCommand command,
        CancellationToken cancellationToken)
    {
        var entity = new Product
        {
            Name = command.Name,
            ProductNumber = command.ProductNumber,
            MakeFlag = command.MakeFlag,
            FinishedGoodsFlag = command.FinishedGoodsFlag,
            Color = command.Color,
            SafetyStockLevel = command.SafetyStockLevel,
            ReorderPoint = command.ReorderPoint,
            StandardCost = command.StandardCost,
            ListPrice = command.ListPrice,
            Size = command.Size,
            SizeUnitMeasureCode = command.SizeUnitMeasureCode,
            WeightUnitMeasureCode = command.WeightUnitMeasureCode,
            Weight = command.Weight,
            DaysToManufacture = command.DaysToManufacture,
            ProductLine = command.ProductLine,
            Class = command.Class,
            Style = command.Style,
            ProductModelId = command.ProductModelId,
            ProductSubcategoryId = command.ProductSubcategoryId,
            SellStartDate = _dateTimeService.Now,
            ModifiedDate = _dateTimeService.Now
        };

        _dbContext.Products.Add(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return new(201, entity.ProductId);
    }
}
