namespace SocialMedia.Core.DTOs
{
    public class APIResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string ResponseCode { get; set; }
        public string Message { get; set; }
        public T Payload { get; set; }
    }
}
