using System.Net;

namespace SocialMedia.Core.DTOs
{
    public class APIResponse<T>
    {
        public bool IsSuccess { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string ExceptionMessage { get; set; }
        public T Payload { get; set; }
    }
}
