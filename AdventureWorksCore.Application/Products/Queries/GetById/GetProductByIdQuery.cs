using AdventureWorksCore.Application.Common.AppRequests;
using AdventureWorksCore.Application.Common.Interfaces;
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
            .FirstOrDefaultAsync(_ => _.ProductId == query.ProductId, cancellationToken);

        if (entity == null)
        {
            return new(404);
        }

        return new(200, ProductDto.MapFromEntity(entity));
    }
}
