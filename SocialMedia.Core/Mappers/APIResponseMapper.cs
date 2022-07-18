using System.Net;
using SocialMedia.Core.DTOs;

namespace SocialMedia.Core.Mappers
{
    public class APIResponseMapper<T>
    {
        public static Response<T> BuildResponse(
            bool isSuccess,
            T data
        )
        {
            return new Response<T>
            {
                IsSuccess = isSuccess,
                Data = data
            };
        }

        public static Response<T> BuildResponse(
            bool isSuccess,
            T data,
            string message
        )
        {
            return new Response<T>
            {
                IsSuccess = isSuccess,
                Data = data,
                Message = message,
            };
        }
    }
}
