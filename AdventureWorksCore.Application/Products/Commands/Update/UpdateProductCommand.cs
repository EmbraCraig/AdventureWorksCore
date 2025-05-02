using AdventureWorksCore.Application.Common.AppRequests;
using AdventureWorksCore.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace AdventureWorksCore.Application.Projects.Commands.Update;

public record UpdateProductCommand
{
    [JsonIgnore]
    public int ProductId { get; init; }

    public string Name { get; init; } = "";
}

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public UpdateProductCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
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

        await _dbContext.SaveChangesAsync(cancellationToken);

        return new(200);
    }
}
