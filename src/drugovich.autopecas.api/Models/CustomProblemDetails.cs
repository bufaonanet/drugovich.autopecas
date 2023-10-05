using Microsoft.AspNetCore.Mvc;

namespace drugovich.autopecas.api.Models;

public class CustomProblemDetails : ProblemDetails
{
    public IDictionary<string, string[]> Erros { get; set; } = new Dictionary<string, string[]>();
}