using AdventureWorksCore.Application.Common.AppRequests;
using AdventureWorksCore.Application.Common.AppRequests.Pagination;
using AdventureWorksCore.Application.Common.Interfaces;
using AdventureWorksCore.Application.Products.Queries;
using AdventureWorksCore.Application.Projects.Dtos;
using AdventureWorksCore.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksCore.Application.Projects.Queries.List;

public record ListProductsQuery : PaginatedListQuery
{

}

public class ListProductsQueryHandler : IRequestHandler<ListProductsQuery, PaginatedListResponse<ProductDto>>
{
    private readonly IApplicationDbContext _dbContext;

    public ListProductsQueryHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<AppResponse<PaginatedListResponse<ProductDto>>> Handle(
        ListProductsQuery query,
        CancellationToken cancellationToken)
    {
        var productQueryable = BuildQueryable(query);

        var result = await PaginatedListResponse<ProductDto>.Create(
            productQueryable,
            query,
            entity => ProductDto.MapFromEntity(entity),
            cancellationToken);

        return new(200, result);
    }

    private IQueryable<Product> BuildQueryable(ListProductsQuery query)
    {
        var queryable = _dbContext.Products
            .Include(x => x.ProductModel)
            .Include(x => x.ProductSubcategory)
            .Include(x => x.ProductReviews)
            .Include(_ => _.BillOfMaterialComponents)
            .Include(_ => _.BillOfMaterialProductAssemblies)
            .Include(x => x.ProductCostHistories)
            .Include(x => x.ProductInventories)
                .ThenInclude(pi => pi.Location)
            .Include(x => x.ProductListPriceHistories)
            .Include(x => x.ProductVendors)
                .ThenInclude(pv => pv.BusinessEntity)
            .Include(x => x.ProductVendors)
                .ThenInclude(pv => pv.UnitMeasureCodeNavigation)
            .Include(x => x.PurchaseOrderDetails)
                .ThenInclude(pod => pod.PurchaseOrder)
            .Include(x => x.WorkOrders)
                .ThenInclude(wo => wo.ScrapReason)
            .Include(x => x.WorkOrders)
                .ThenInclude(wo => wo.WorkOrderRoutings)
                    .ThenInclude(wor => wor.Location)
            .Include(x => x.ProductProductPhotos).ThenInclude(ppp => ppp.ProductPhoto);

        return queryable;
    }

    public async Task<AppResponse<PaginatedListResponse<ProductDto>>> HandleV2(
        ListProductsQuery query,
        CancellationToken cancellationToken)
    {
        var result = await PaginatedListResponse<ProductDto>.Create<ProductDto>(
            _dbContext.Products.ProjectToDto().OrderBy(_ => _.Id),
            query,
            cancellationToken);

        return new(200, result);
    }
}
