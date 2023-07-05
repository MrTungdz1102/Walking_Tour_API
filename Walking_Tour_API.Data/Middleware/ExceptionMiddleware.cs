using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;
using Walking_Tour_API.Infrastructure.Exception;

namespace Walking_Tour_API.Infrastructure.Middleware
{
	public class ExceptionMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<ExceptionMiddleware> _logger;

		public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
		{
			this._next = next;
			this._logger = logger;
		}

		// package k tim duoc
		// <ItemGroup>
		// < FrameworkReference Include="Microsoft.AspNetCore.App" />
		//</ItemGroup>

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (System.Exception ex)
			{
				_logger.LogError(ex, $"Something Went wrong while processing {context.Request.Path}");
				await HandleExceptionAsync(context, ex);
			}
		}

		private Task HandleExceptionAsync(HttpContext context, System.Exception ex)
		{
			context.Response.ContentType = "application/json";
			HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
			var errorDetails = new ErrorDeatils
			{
				ErrorType = "Failure",
				ErrorMessage = ex.Message,
			};

			switch (ex)
			{
				case NotFoundException notFoundException:
					statusCode = HttpStatusCode.NotFound;
					errorDetails.ErrorType = "Not Found";
					break;
				case BadRequestException badRequestException:
					statusCode = HttpStatusCode.BadRequest;
					errorDetails.ErrorType = "Bad Request";
					break;
				default:
					break;
			}

			string response = JsonConvert.SerializeObject(errorDetails);
			context.Response.StatusCode = (int)statusCode;
			return context.Response.WriteAsync(response);
		}
	}

	public class ErrorDeatils
	{
		public string ErrorType { get; set; }
		public string ErrorMessage { get; set; }
	}
}
