using System.Collections.Generic;
using System.Threading.Tasks;
using SocialMedia.Core.DTOs.Query;

namespace SocialMedia.Core.Interfaces.Query
{
  public interface IPostRepositoryQuery
  {
    Task<IEnumerable<PostDTO>> GetPosts();
    Task<PostDTO> GetPost(int id);
  }
}