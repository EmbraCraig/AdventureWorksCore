using AdventureWorksCore.Application.Common.AppRequests;
using AdventureWorksCore.Application.Common.AppRequests.Pagination;
using AdventureWorksCore.Application.Common.Interfaces;
using AdventureWorksCore.Application.Projects.Dtos;
using AdventureWorksCore.Models;

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
        var queryable = _dbContext.Products;

        return queryable;
    }
}
