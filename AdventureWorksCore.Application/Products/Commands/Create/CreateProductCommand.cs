using AdventureWorksCore.Application.Common.AppRequests;
using AdventureWorksCore.Application.Common.Interfaces;
using AdventureWorksCore.Models;

namespace AdventureWorksCore.Application.Products.Commands.Create;

public class CreateProductCommand
{
    public string Name { get; init; } = null!;
}

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IApplicationDbContext _dbContext;

    public CreateProductCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<AppResponse<int>> Handle(
        CreateProductCommand command,
        CancellationToken cancellationToken)
    {
        var entity = new Product
        {
            Name = command.Name,
        };

        _dbContext.Products.Add(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return new(201, entity.ProductId);
    }
}
