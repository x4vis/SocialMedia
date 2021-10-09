using System.Threading.Tasks;
using SocialMedia.Core.DTOs.Query;

namespace SocialMedia.Core.Interfaces.Command
{
  public interface IPostRepositoryCommand
  {
    Task<int> AddPost(PostDTO model);
  }
}