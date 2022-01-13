using System.Collections.Generic;
using System.Threading.Tasks;
using SocialMedia.Core.DTOs.Query;

namespace SocialMedia.Core.Interfaces.Query
{
    public interface IPostQueryRepository
    {
        Task<List<PostDTO>> GetPostsAsync();
        Task<PostDTO> GetPostAsync(int id);
    }
}