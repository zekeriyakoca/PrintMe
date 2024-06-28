namespace PrintMe.Application.DomainExceptions;

public class CatalogDomainException : BussinessException
{
    public CatalogDomainException(string message) : base(message)
    {
        
    }
}