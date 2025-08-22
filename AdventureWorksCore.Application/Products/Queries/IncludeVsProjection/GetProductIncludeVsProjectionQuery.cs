using AdventureWorksCore.Application.Common.AppRequests;
using AdventureWorksCore.Application.Common.Interfaces;
using AdventureWorksCore.Application.Products.Dtos;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksCore.Application.Products.Queries.IncludeVsProjection;

public record GetProductIncludeVsProjectionQuery
{
    public int ProductId { get; init; }
}

public class GetProductIncludeVsProjectionQueryHandler : IRequestHandler<GetProductIncludeVsProjectionQuery, ProductSummaryDto>
{
    private readonly IApplicationDbContext _dbContext;

    public GetProductIncludeVsProjectionQueryHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// V1: Include + MapFromEntity approach
    /// Uses Include statements to load related entities, then maps to DTO
    /// Results in loading full entities into memory, then mapping
    /// SQL: Complex JOINs that load all columns from related tables
    /// </summary>
    public async Task<AppResponse<ProductSummaryDto>> Handle(
        GetProductIncludeVsProjectionQuery query,
        CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Products
            .Include(p => p.ProductModel)                           // Load full ProductModel entity
            .Include(p => p.ProductSubcategory)                     // Load full ProductSubcategory entity
                .ThenInclude(ps => ps.ProductCategory)              // Load full ProductCategory entity
            .Include(p => p.SizeUnitMeasureCodeNavigation)          // Load full UnitMeasure entity for size
            .Include(p => p.WeightUnitMeasureCodeNavigation)        // Load full UnitMeasure entity for weight
            .FirstOrDefaultAsync(p => p.ProductId == query.ProductId, cancellationToken);

        if (entity == null)
        {
            return new(404);
        }

        // Map loaded entities to DTO
        return new(200, ProductSummaryDto.MapFromEntity(entity));
    }

    /// <summary>
    /// V2: Projection approach using extension method
    /// Uses ProjectToSummaryDto extension method for clean projection
    /// Results in optimized SQL that only selects required columns
    /// SQL: Simple SELECT with JOINs that only fetch needed columns
    /// </summary>
    public async Task<AppResponse<ProductSummaryDto>> HandleV2(
        GetProductIncludeVsProjectionQuery query,
        CancellationToken cancellationToken)
    {
        var dto = await _dbContext.Products
            .Where(p => p.ProductId == query.ProductId)
            .ProjectToSummaryDto()  // Use extension method for projection
            .FirstOrDefaultAsync(cancellationToken);

        if (dto == null)
        {
            return new(404);
        }

        return new(200, dto);
    }
}