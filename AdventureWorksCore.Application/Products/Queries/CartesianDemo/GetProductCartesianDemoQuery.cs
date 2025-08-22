using AdventureWorksCore.Application.Common.AppRequests;
using AdventureWorksCore.Application.Common.Interfaces;
using AdventureWorksCore.Application.Projects.Dtos;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksCore.Application.Products.Queries.CartesianDemo;

public record GetProductCartesianDemoQuery
{
    public int ProductId { get; init; }
}

public class GetProductCartesianDemoQueryHandler : IRequestHandler<GetProductCartesianDemoQuery, ProductDto>
{
    private readonly IApplicationDbContext _dbContext;

    public GetProductCartesianDemoQueryHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// V1: BAD EXAMPLE - Demonstrates cartesian explosion
    /// When multiple collections are included, EF Core generates a single query with JOINs
    /// that creates a cartesian product. If a product has:
    /// - 3 reviews
    /// - 5 photos  
    /// - 4 vendors
    /// - 2 cost histories
    /// The query will return 3 × 5 × 4 × 2 = 120 rows instead of 1 product!
    /// </summary>
    public async Task<AppResponse<ProductDto>> Handle(
        GetProductCartesianDemoQuery query,
        CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Products
            .Include(p => p.ProductModel)
            .Include(p => p.ProductSubcategory)
                .ThenInclude(ps => ps.ProductCategory)
            // These collections will create cartesian explosion:
            .Include(p => p.ProductReviews)           // Collection 1
            .Include(p => p.ProductProductPhotos)     // Collection 2
                .ThenInclude(ppp => ppp.ProductPhoto)
            .Include(p => p.ProductVendors)           // Collection 3
                .ThenInclude(pv => pv.BusinessEntity)
            .Include(p => p.ProductVendors)
                .ThenInclude(pv => pv.UnitMeasureCodeNavigation)
            .Include(p => p.ProductCostHistories)     // Collection 4
            .Include(p => p.ProductInventories)       // Collection 5
                .ThenInclude(pi => pi.Location)
            .Include(p => p.ProductListPriceHistories) // Collection 6
            // Note: Not using AsSplitQuery() here to demonstrate the problem
            .FirstOrDefaultAsync(p => p.ProductId == query.ProductId, cancellationToken);

        if (entity == null)
        {
            return new(404);
        }

        return new(200, ProductDto.MapFromEntity(entity));
    }

    /// <summary>
    /// V2: GOOD EXAMPLE - Uses AsSplitQuery to avoid cartesian explosion
    /// AsSplitQuery tells EF Core to execute separate queries for each Include,
    /// avoiding the multiplication effect while still loading all related data efficiently.
    /// </summary>
    public async Task<AppResponse<ProductDto>> HandleV2(
        GetProductCartesianDemoQuery query,
        CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Products
            .Include(p => p.ProductModel)
            .Include(p => p.ProductSubcategory)
                .ThenInclude(ps => ps.ProductCategory)
            // Same collections as V1, but with AsSplitQuery:
            .Include(p => p.ProductReviews)
            .Include(p => p.ProductProductPhotos)
                .ThenInclude(ppp => ppp.ProductPhoto)
            .Include(p => p.ProductVendors)
                .ThenInclude(pv => pv.BusinessEntity)
            .Include(p => p.ProductVendors)
                .ThenInclude(pv => pv.UnitMeasureCodeNavigation)
            .Include(p => p.ProductCostHistories)
            .Include(p => p.ProductInventories)
                .ThenInclude(pi => pi.Location)
            .Include(p => p.ProductListPriceHistories)
            .AsSplitQuery() // This solves the cartesian explosion!
            .FirstOrDefaultAsync(p => p.ProductId == query.ProductId, cancellationToken);

        if (entity == null)
        {
            return new(404);
        }

        return new(200, ProductDto.MapFromEntity(entity));
    }
}