﻿using FluentValidation;

namespace Application.Features.Finance.Command.CreateFinance;

public class CreateFinanceCommandValidator : AbstractValidator<CreateFinanceCommand>
{
    public CreateFinanceCommandValidator()
    {
        RuleFor(f => f.Title)
            .NotEmpty().NotNull().WithMessage("{PropertyName} is requried ")
            .MaximumLength(70).WithMessage("{PropertyNme} must be fewer than 70 characters");
    }
}

