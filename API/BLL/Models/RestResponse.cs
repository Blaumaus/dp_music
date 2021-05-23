
namespace BLL.Models
{
    public class RestResponse<T>
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }

        public static RestResponse<T> Fail(int statusCode, string errorMessage)
        {
            return new RestResponse<T> { StatusCode = statusCode, ErrorMessage = errorMessage };
        }

        public static RestResponse<T> Success(T data)
        {
            return new RestResponse<T> { Data = data };
        }

        public static RestResponse<T> Unauthorized()
        {
            const int unauthorizedStatusCode = 401;
            return new RestResponse<T> { StatusCode = unauthorizedStatusCode, ErrorMessage = "User is not authorized" };
        }
    }
}
