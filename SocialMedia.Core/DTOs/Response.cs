namespace SocialMedia.Core.DTOs
{
    public class Response<T>
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
    }
}
