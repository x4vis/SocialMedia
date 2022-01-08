using System.Threading.Tasks;
using SocialMedia.Core.DTOs.Command;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Enums;

namespace SocialMedia.Core.Interfaces.Command
{
    public interface IPostCommandRepository
    {
        Task<int> AddPostAsync(Post model);
        Task<UpdateOrDeleteResource> UpdatePostAsync(int postId, UpdatePostDTO model);
        Task<UpdateOrDeleteResource> DeletePostAsync(int postId);
    }
}