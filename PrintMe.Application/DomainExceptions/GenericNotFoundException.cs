namespace PrintMe.Application.DomainExceptions;

public class GenericNotFoundException : BussinessException
{
    public GenericNotFoundException(string message) : base(message)
    {
        
    }
}