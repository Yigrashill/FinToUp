namespace Application.Contracts.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string name, object key) 
        :base($"{name} in ({key}) wos not found")
    {
    }
}