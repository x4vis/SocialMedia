using System.Threading.Tasks;
using SocialMedia.Core.DTOs.Command;
using SocialMedia.Core.Enums;

namespace SocialMedia.Core.Interfaces.Command
{
    public interface IPostCommandService
    {
        Task<SaveResource> AddPostAsync(AddPostDTO model);
    }
}
