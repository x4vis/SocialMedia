using System.Threading.Tasks;
using SocialMedia.Core.DTOs.Command;
using SocialMedia.Core.Enums;

namespace SocialMedia.Core.Interfaces.Command
{
    public interface IPostRepositoryCommand
    {
        Task<SaveResource> AddPostAsync(AddPostDTO model);
        Task<UpdateOrDeleteResource> UpdatePostAsync(int postId, UpdatePostDTO model);
        Task<UpdateOrDeleteResource> DeletePostAsync(int postId);
    }
}