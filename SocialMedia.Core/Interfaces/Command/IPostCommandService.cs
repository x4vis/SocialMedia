using System.Threading.Tasks;
using SocialMedia.Core.DTOs.Command;
using SocialMedia.Core.Enums;

namespace SocialMedia.Core.Interfaces.Command
{
    public interface IPostCommandService
    {
        Task<WriteEntity> AddPostAsync(AddPostDTO model);
        Task<WriteEntity> UpdatePostAsync(UpdatePostDTO model);
        Task<WriteEntity> DeletePostAsync(int postId);
    }
}
