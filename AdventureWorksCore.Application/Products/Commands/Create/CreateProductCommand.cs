using AdventureWorksCore.Application.Common.AppRequests;
using AdventureWorksCore.Application.Common.Interfaces;
using AdventureWorksCore.Models;

namespace AdventureWorksCore.Application.Products.Commands.Create;

public class CreateProductCommand
{
    public string Name { get; init; } = null!;
    public string ProductNumber { get; init; } = null!;
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
            SellStartDate = _dateTimeService.Now,
        };

        _dbContext.Products.Add(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return new(201, entity.ProductId);
    }
}
