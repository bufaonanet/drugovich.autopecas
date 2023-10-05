using FluentValidation.Results;

namespace drugovich.autopecas.application.Exceptions;

public class BadRequestException : Exception
{
    public IDictionary<string, string[]> ValidationErros { get; set; }
    
    public BadRequestException(string message)
        : base(message) { }
    
    public BadRequestException(string message, ValidationResult validationResult)
        : base(message)
    {
        ValidationErros = validationResult.ToDictionary();
    }
}