using System.Collections.Generic;
using System.Threading.Tasks;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.DTOs.Query;

namespace SocialMedia.Core.Interfaces.Query
{
    public interface IPostQueryService
    {
        Task<APIResponse<IEnumerable<PostDTO>>> GetPostsAsync();
        Task<APIResponse<PostDTO>> GetPostAsync(int id);
    }
}
