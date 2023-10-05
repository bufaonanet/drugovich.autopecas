namespace drugovich.autopecas.application.Exceptions;

public class DomainException: Exception
{
    public DomainException(string message) : base(message) { }
}