namespace PrintMe.Application.DomainExceptions;

public class BussinessException : Exception
{
    public BussinessException(string message) : base(message)
    {
        BussinessMessage = message;
    }

    public string BussinessMessage { get; set; }
}