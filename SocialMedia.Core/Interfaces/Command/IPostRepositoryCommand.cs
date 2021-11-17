using System.Threading.Tasks;
using SocialMedia.Core.DTOs.Command;

namespace SocialMedia.Core.Interfaces.Command
{
    public interface IPostRepositoryCommand
    {
        Task<int> AddPost(AddPostDTO model);
    }
}