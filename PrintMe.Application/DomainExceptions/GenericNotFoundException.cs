namespace PrintMe.Application.DomainExceptions;

public class GenericNotFoundException : Exception
{
    public GenericNotFoundException(string message) : base(message)
    {
        
    }
}