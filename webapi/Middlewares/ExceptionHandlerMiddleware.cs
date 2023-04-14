using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using UserManager.Core.Exceptions;

namespace webapi.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IHostEnvironment _host;
    private readonly ILogger<Microsoft.AspNetCore.Diagnostics.ExceptionHandlerMiddleware> _logger;

    public ExceptionHandlerMiddleware(RequestDelegate next, IHostEnvironment host, ILogger<Microsoft.AspNetCore.Diagnostics.ExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _host = host;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.InnerException?.Message ?? e.Message);
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = _host.IsDevelopment()
                ? new ApiException(httpContext.Response.StatusCode, e.InnerException?.Message ?? e.Message, e.StackTrace ?? "Something went wrong!")
                : new ApiException(httpContext.Response.StatusCode, e.InnerException?.Message ?? e.Message, "Internal Server Error");

            await httpContext.Response.WriteAsJsonAsync(response);
        }
    }
}

public static class ExceptionHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}
