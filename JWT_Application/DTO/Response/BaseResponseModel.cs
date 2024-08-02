namespace JWT_Application.DTO.Response
{
    public class BaseResponseModel<T>
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public T Data { get; set; }
    }
}
