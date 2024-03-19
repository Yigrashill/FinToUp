namespace Application.Contracts.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string name, object key) 
        :base($"{name} in now ({key}) wos not found")
    {
    }
}