namespace drugovich.autopecas.application.Exceptions;

public class NotFoundException: ApplicationException
{
    public NotFoundException(string name, object key)
        : base($"{name} ({key}) não foi encontrado!") { }
}