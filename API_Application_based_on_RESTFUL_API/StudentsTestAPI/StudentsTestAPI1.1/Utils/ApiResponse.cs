namespace StudentsTestAPI1._1.Utils
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message {  get; set; }
        
        public T Result { get; set; }

        public int StatusCode {  get; set; }

        public static ApiResponse<T> ResponseSuccess(T data, string message)
        {
            return new ApiResponse<T>
            {
                Success = true,
                Message = message,
                Result = data,
                StatusCode = 200
            };
        }

        public static ApiResponse<T> ResponseFailed(string message, int statuscode = 500)
        {
            return new ApiResponse<T>
            {
                Success = false,
                Message = message,
                Result = default,
                StatusCode = statuscode
            };
        }
    }
}
