namespace Application.Contracts.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(string message) 
        : base(message) 
    {
        // TODO can return some 400 status code.
        // Can return some Validation Value
    }
}
