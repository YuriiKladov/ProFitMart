using System.Net;
using Serilog;

public sealed class GlobalExceptionMiddleware
{
	private readonly RequestDelegate _next;

	public GlobalExceptionMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task Invoke(HttpContext context)
	{
		try
		{
			await _next(context);
		}
		catch (Exception ex)
		{
			Log.Error(ex, "Unhandled exception occurred");

			context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
			context.Response.ContentType = "application/json";

			var errorResponse = new
			{
				StatusCode = context.Response.StatusCode,
				Message = "Internal Server Error",
				Details = ex.Message //
			};

			await context.Response.WriteAsJsonAsync(errorResponse);
		}
	}
}
