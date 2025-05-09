using FluentValidation;

namespace AdventureWorksCore.Application.Products.Commands.Create;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(_ => _.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(_ => _.ProductNumber)
            .NotNull()
            .NotEmpty()
            .MaximumLength(25);

        RuleFor(_ => _.SafetyStockLevel)
            .GreaterThan((short)0);

        RuleFor(_ => _.ReorderPoint)
            .GreaterThan((short)0);

        RuleFor(_ => _.StandardCost)
            .GreaterThanOrEqualTo(0);

        RuleFor(_ => _.ListPrice)
            .GreaterThanOrEqualTo(0);

        RuleFor(_ => _.Size)
            .MaximumLength(5)
            .When(_ => _.Size != null);

        RuleFor(_ => _.SizeUnitMeasureCode)
            .MaximumLength(3)
            .When(_ => _.SizeUnitMeasureCode != null);

        RuleFor(_ => _.WeightUnitMeasureCode)
            .MaximumLength(3)
            .When(_ => _.WeightUnitMeasureCode != null);

        RuleFor(_ => _.Weight)
            .GreaterThan(0)
            .When(_ => _.Weight.HasValue);

        RuleFor(_ => _.DaysToManufacture)
            .GreaterThanOrEqualTo(0);

        RuleFor(_ => _.ProductLine)
            .MaximumLength(2)
            .When(_ => _.ProductLine != null);

        RuleFor(_ => _.Class)
            .MaximumLength(2)
            .When(_ => _.Class != null);

        RuleFor(_ => _.Style)
            .MaximumLength(2)
            .When(_ => _.Style != null);

        RuleFor(_ => _.Color)
            .MaximumLength(15)
            .When(_ => _.Color != null);
    }
}
