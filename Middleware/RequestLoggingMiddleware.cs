using System.Diagnostics;

namespace ProductApi.Middleware;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();
        var method = context.Request.Method;
        var path = context.Request.Path;

        _logger.LogInformation(">>> Request: {Method} {Path} - Bắt đầu xử lý", method, path);

        await _next(context);

        stopwatch.Stop();
        var statusCode = context.Response.StatusCode;
        var elapsedMs = stopwatch.ElapsedMilliseconds;

        _logger.LogInformation("<<< Response: {Method} {Path} - Status: {StatusCode} - Thời gian: {ElapsedMs}ms",
            method, path, statusCode, elapsedMs);
    }
}
