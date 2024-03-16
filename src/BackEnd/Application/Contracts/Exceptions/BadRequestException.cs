
using FluentValidation.Results;

namespace Application.Contracts.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(string message) 
        : base(message) 
    {
        // TODO can return some 400 status code.
        // Can return some Validation Value
    }

    public BadRequestException(string message, ValidationResult validationResult)
        :base(message)
    {
        ValidationErrors = new();
        foreach (var error in validationResult.Errors) 
        {
            ValidationErrors.Add(error.ErrorMessage);
        }
    }

    public List<string> ValidationErrors { get; set; }
}
