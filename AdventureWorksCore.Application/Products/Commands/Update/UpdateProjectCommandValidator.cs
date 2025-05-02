using AdventureWorksCore.Application.Products.Commands.Create;
using FluentValidation;

namespace AdventureWorksCore.Application.Projects.Commands.Update;

public class UpdateProjectCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProjectCommandValidator()
    {
        RuleFor(_ => _.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(256);
    }
}
