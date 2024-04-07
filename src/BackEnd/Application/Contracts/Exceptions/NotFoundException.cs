namespace Application.Contracts.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string name, object key) 
        :base($"{name} wthit key: ({key}) wos not found")
    {
    }
}