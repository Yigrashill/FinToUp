using FluentValidation;

namespace Application.Features.Finance.Command.CreateFinance;

public class CreateFinanceCommandValidation : AbstractValidator<CreateFinanceCommand>
{
    public CreateFinanceCommandValidation()
    {
        RuleFor(f => f.Title)
            .NotEmpty().NotNull().WithMessage("{PropertyName} is requried ")
            .MaximumLength(70).WithMessage("{PropertyNme} must be fewer than 70 characters");
    }
}

