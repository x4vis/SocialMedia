using System.Collections.Generic;
using System.Threading.Tasks;
using SocialMedia.Core.DTOs.Query;

namespace SocialMedia.Core.Interfaces.Query
{
    public interface IPostQueryService
    {
        Task<List<PostDTO>> GetPostsAsync();
        Task<PostDTO> GetPostAsync(int id);
    }
}
