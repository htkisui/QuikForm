using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
            if (context.Response.StatusCode == 404)
            {
                context.Response.Redirect("/Home/Error", false);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception caught.");

            // Rediriger vers une page d'erreur 404
            context.Response.StatusCode = 404;
            context.Response.Redirect("/Home/Error", false);
        }
    }
}

// Extension méthode pour ajouter le middleware à la pipeline de requête
public static class ErrorHandlingMiddlewareExtension
{
    public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ErrorHandlingMiddleware>();
    }
}