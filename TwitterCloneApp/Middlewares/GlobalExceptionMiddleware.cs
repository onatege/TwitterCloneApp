using System.Net;
using System.Text.Json;
using TwitterCloneApp.Service.Exceptions;

namespace TwitterCloneApp.Middlewares
{
	public class GlobalExceptionMiddleware
	{
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
			_next = next;
			_logger = logger;
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next.Invoke(context);
			}
			catch (Exception err)
			{
				var response = context.Response;
				response.ContentType = "application/json";
				string message;
				HttpStatusCode statusCode;
				if (err is ClientSideException)
				{
					statusCode = HttpStatusCode.BadRequest;
					message = err.Message;
				}
				else if (err is NotFoundException)
				{
					statusCode = HttpStatusCode.NotFound;
					message = err.Message;
				}
				else if (err is BadRequestException)
				{
					statusCode = HttpStatusCode.BadRequest;
					message = err.Message;
				}
				else
				{
					message = err.Message;
					statusCode = HttpStatusCode.InternalServerError;
				}

				response.StatusCode = (int)statusCode;
				
				var result = JsonSerializer.Serialize(new {err = message});
				await response.WriteAsync(result);
			}
		} 
    }
}
