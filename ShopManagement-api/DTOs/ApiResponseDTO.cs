namespace ShopManagement_api.DTOs
{
    public class ApiResponseDTO<T>
    {
        public bool IsSuccess  { get; set; } = false;       // true / false
        public string? Message { get; set; } = "";    // เช่น “Success”, “Invalid input”
        public T? Data { get; set; }
        public string? ErrorCode { get; set; }
        public List<string>? Errors { get; set; }

        public static ApiResponseDTO<T> Success(T? data = default, string? message = null)
        {
            return new ApiResponseDTO<T>
            {
                IsSuccess = true,
                Message = message,
                Data = data
            };
        }
        public static ApiResponseDTO<T> Failure(string? errorCode = null, string? message = null, List<string>? errors = null)
        {
            return new ApiResponseDTO<T>
            {
                IsSuccess = false,
                ErrorCode = errorCode,
                Message = message,
                Errors = errors
            };
        }
    }
}
