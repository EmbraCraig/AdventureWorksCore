using AdventureWorksCore.Application.Common.AppRequests;
using AdventureWorksCore.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksCore.Application.Projects.Commands.Delete;

public record DeleteProductCommand
{
    public required int ProductId { get; init; }
}

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public DeleteProductCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<AppResponse> Handle(
        DeleteProductCommand command,
        CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Products
            .FirstOrDefaultAsync(_ => _.ProductId == command.ProductId, cancellationToken);

        if (entity is null)
        {
            return new(404);
        }

        _dbContext.Products.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return new(200);
    }
}
