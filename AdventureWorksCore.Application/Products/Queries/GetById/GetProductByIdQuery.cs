using AdventureWorksCore.Application.Common.AppRequests;
using AdventureWorksCore.Application.Common.Interfaces;
using AdventureWorksCore.Application.Products.Queries;
using AdventureWorksCore.Application.Projects.Dtos;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksCore.Application.Projects.Queries.GetById;

public record GetProductByIdQuery
{
    public int ProductId { get; init; }
}

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
{
    private readonly IApplicationDbContext _dbContext;

    public GetProductByIdQueryHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<AppResponse<ProductDto>> Handle(
        GetProductByIdQuery query,
        CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Products
            .Include(_ => _.ProductModel)
            .Include(_ => _.ProductSubcategory)
            .Include(_ => _.ProductReviews)
            .Include(_ => _.BillOfMaterialComponents)
            .Include(_ => _.BillOfMaterialProductAssemblies)
            .Include(_ => _.ProductCostHistories)
            .Include(_ => _.ProductInventories)
                .ThenInclude(pi => pi.Location)
            .Include(_ => _.ProductListPriceHistories)
            .Include(_ => _.ProductVendors)
                .ThenInclude(pv => pv.BusinessEntity)
            .Include(_ => _.ProductVendors)
                .ThenInclude(pv => pv.UnitMeasureCodeNavigation)
            .Include(_ => _.PurchaseOrderDetails)
                .ThenInclude(pod => pod.PurchaseOrder)
            .Include(_ => _.WorkOrders)
                .ThenInclude(wo => wo.ScrapReason)
            .Include(_ => _.WorkOrders)
                .ThenInclude(wo => wo.WorkOrderRoutings)
                    .ThenInclude(wor => wor.Location)
            .Include(x => x.ProductProductPhotos).ThenInclude(ppp => ppp.ProductPhoto)
            .FirstOrDefaultAsync(_ => _.ProductId == query.ProductId, cancellationToken);

        if (entity == null)
        {
            return new(404);
        }

        return new(200, ProductDto.MapFromEntity(entity));
    }

    public async Task<AppResponse<ProductDto>> HandleV2(
        GetProductByIdQuery query,
        CancellationToken cancellationToken)
    {
        var dto = await _dbContext.Products
            .Where(_ => _.ProductId == query.ProductId)
            .ProjectToDto()
            .FirstOrDefaultAsync(cancellationToken);

        if (dto == null)
        {
            return new(404);
        }

        return new(200, dto);
    }
}
