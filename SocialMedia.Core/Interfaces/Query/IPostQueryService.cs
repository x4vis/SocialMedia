using System.Collections.Generic;
using System.Threading.Tasks;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.DTOs.Query;

namespace SocialMedia.Core.Interfaces.Query
{
    public interface IPostQueryService
    {
        Task<Response<IEnumerable<PostDTO>>> GetPostsAsync();
        Task<Response<PostDTO>> GetPostAsync(int id);
    }
}
