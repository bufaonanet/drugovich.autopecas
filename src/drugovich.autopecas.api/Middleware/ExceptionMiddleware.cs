using System.Net;
using drugovich.autopecas.api.Models;
using drugovich.autopecas.application.Exceptions;
using Newtonsoft.Json;

namespace drugovich.autopecas.api.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ApplicationException ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }
    
    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var httpStatusCode = HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";
        var result = string.Empty;

        switch (exception)
        {
            case BadRequestException badRequest:
                httpStatusCode = HttpStatusCode.BadRequest;
                break;
            case NotFoundException notFound:
                httpStatusCode = HttpStatusCode.NotFound;
                break;
            case DomainException domainException:
                httpStatusCode = HttpStatusCode.BadRequest;
                break;
            default:
                httpStatusCode = HttpStatusCode.BadRequest;
                break;
        }
        
        context.Response.StatusCode = (int)httpStatusCode;

        if (result == string.Empty)
        {
            result = JsonConvert.SerializeObject(new { error = exception.Message });
        }
        _logger.LogError(result);
        await context.Response.WriteAsJsonAsync(result);
    }
}