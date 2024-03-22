using FluentValidation;

namespace Application.Features.Finance.Command.UpdateCommand;

public class UpdateFinanceCommandValidator: AbstractValidator<UpdateFinanceCommand>
{
    public UpdateFinanceCommandValidator()
    {
        RuleFor(f => f.Title)
            .NotEmpty().NotNull().WithMessage("{PropertyName} is requried ")
            .MaximumLength(70).WithMessage("{PropertyNme} must be fewer than 70 characters");
    }
}