using System.Diagnostics;

namespace MovieLib.WebApplication.Middleware;

public class RequestTimingMiddleware
{
	// Middleware for measuring the time needed for requests.
	private readonly RequestDelegate _next;
	public RequestTimingMiddleware(RequestDelegate next)
	{
		_next = next;
	}
	public async Task InvokeAsync(HttpContext ctx)
	{
		var stopwatch = new Stopwatch();
		stopwatch.Start();

		await _next(ctx);

		stopwatch.Stop();

		Console.WriteLine($"Request took:{stopwatch.ElapsedMilliseconds} ms");

	}
}
public static class RequestTimingMiddlewareExtensions
{
	
	public static IApplicationBuilder UseRequestTiming(this IApplicationBuilder builder)
	{
		return builder.UseMiddleware<RequestTimingMiddleware>();
	}
}

