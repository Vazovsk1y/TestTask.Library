using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace TestTest.WebApi.Middlewares;

public class ExceptionsHandlingMiddleware : IMiddleware
{
	private readonly ILogger<ExceptionsHandlingMiddleware> _logger;

	public ExceptionsHandlingMiddleware(ILogger<ExceptionsHandlingMiddleware> logger) =>
		_logger = logger;

	public async Task InvokeAsync(HttpContext context, RequestDelegate next)
	{
		try
		{
			await next(context);
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, nameof(HttpStatusCode.InternalServerError));
			await HandleExeptionAsync(context, ex, HttpStatusCode.InternalServerError);
		}
	}

	private static async Task HandleExeptionAsync(HttpContext context, Exception exception, HttpStatusCode httpStatusCode)
	{
		HttpResponse response = context.Response;
		response.ContentType = "application/json";
		response.StatusCode = (int)httpStatusCode;

		ProblemDetails problemDetails = new()
		{
			Status = (int)httpStatusCode,
			Title = nameof(HttpStatusCode.InternalServerError),
			Type = exception.GetType().Name,
			Detail = "An error occurred while processing the http request."
		};

		await response.WriteAsJsonAsync(problemDetails);
	}
}
