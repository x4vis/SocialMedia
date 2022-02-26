using System.Net;
using SocialMedia.Core.DTOs;

namespace SocialMedia.Core.Mappers
{
    public class APIResponseMapper<T>
    {
        public static APIResponse<T> BuildResponse(
            bool isSuccess,
            HttpStatusCode statusCode,
            T payload
        )
        {
            return new APIResponse<T>
            {
                IsSuccess = isSuccess,
                StatusCode = statusCode,
                Payload = payload
            };
        }

        public static APIResponse<T> BuildResponse(
            bool isSuccess,
            HttpStatusCode statusCode,
            T payload,
            string ExceptionMessage
        )
        {
            return new APIResponse<T>
            {
                IsSuccess = isSuccess,
                StatusCode = statusCode,
                ExceptionMessage = ExceptionMessage,
                Payload = payload
            };
        }
    }
}
