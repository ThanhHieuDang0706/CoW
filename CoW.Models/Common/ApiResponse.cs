namespace CoW.Models.Common
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public ApiResponse(bool success, string message, T data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public ApiResponse(bool success, string message)
        {
            Success = success;
            Message = message;
            Data = default;
        }

        public ApiResponse(bool success, T data)
        {
            Success = success;
            Message = string.Empty;
            Data = data;
        }

        public ApiResponse(T data)
        {
            Success = true;
            Message = string.Empty;
            Data = data;
        }

        public ApiResponse()
        {
            Success = true;
            Message = string.Empty;
            Data = default;
        }

        public static ApiResponse<T> Ok(T data)
        {
            return new ApiResponse<T>(true, data);
        }

        public static ApiResponse<T> Ok(string message, T data)
        {
            return new ApiResponse<T>(true, message, data);
        }

        public static ApiResponse<T> Error(string message)
        {
            return new ApiResponse<T>(false, message);
        }

        public static ApiResponse<T> Error(string message, T data)
        {
            return new ApiResponse<T>(false, message, data);
        }

        public static ApiResponse<T> Error(string message, T data, bool success)
        {
            return new ApiResponse<T>(success, message, data);
        }

        public static ApiResponse<T> Error(T data)
        {
            return new ApiResponse<T>(false, data);
        }

        public static ApiResponse<T> Error()
        {
            return new ApiResponse<T>(false, string.Empty);
        }

        public static ApiResponse<T> Error(string message, bool success)
        {
            return new ApiResponse<T>(success, message);
        }
    }
}
