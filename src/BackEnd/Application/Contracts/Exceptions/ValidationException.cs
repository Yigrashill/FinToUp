﻿using FluentValidation.Results;

namespace Application.Contracts.Exceptions;

public class ValidationException : Exception
{
    public ValidationException(string message) 
        : base(message) 
    {
        // TODO can return some error status 400 status code.
        // Can return some Validation Value
        // Can return some Individual Error Class not only message
    }

    public ValidationException(string message, ValidationResult validationResult)
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
