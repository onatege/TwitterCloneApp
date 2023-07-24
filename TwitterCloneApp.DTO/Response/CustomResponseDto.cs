using System.Net;

namespace TwitterCloneApp.DTO.Response
{
	public class CustomResponseDto<T>
	{
		public object Data { get; set; }
		public List<string> Error { get; set; }
		public HttpStatusCode StatusCode { get; set; }
		public static CustomResponseDto<T> Success(T data, HttpStatusCode statusCode)
		{
			return new CustomResponseDto<T> { Data = data, StatusCode = statusCode, Error = null};
		}
		public static CustomResponseDto<T> Fail(T data, HttpStatusCode statusCode, List<string> error)
		{
			return new CustomResponseDto<T> { Data = data, StatusCode = statusCode, Error = error };
		}
	}
}
