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
				switch (err)
				{
					case ClientSideException clientSideException:
						statusCode = HttpStatusCode.BadRequest;
						message = clientSideException.Message;
						break;
					case NotFoundException notFoundException:
						statusCode = HttpStatusCode.NotFound;
						message = notFoundException.Message;
						break;
					case BadRequestException badRequestException:
						statusCode = HttpStatusCode.BadRequest;
						message = badRequestException.Message;
						break;
					default:
						statusCode = HttpStatusCode.InternalServerError;
						message = err.Message;
						break;
				}

				response.StatusCode = (int)statusCode;
				
				var result = JsonSerializer.Serialize(new {err = message});
				await response.WriteAsync(result);
			}
		} 
    }
}
