using SocialMedia.Core.DTOs;

namespace SocialMedia.Core.Mappers
{
    public class APIResponseMapper<T>
    {
        public static APIResponse<T> BuildResponse(
            bool isSuccess,
            string responseCode,
            T payload,
            string message = ""
        )
        {
            return new APIResponse<T>
            {
                IsSuccess = isSuccess,
                ResponseCode = responseCode,
                Message = message,
                Payload = payload
            };
        }
    }
}
