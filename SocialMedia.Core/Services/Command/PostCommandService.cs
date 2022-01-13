using System.Threading.Tasks;
using SocialMedia.Core.DTOs.Command;
using SocialMedia.Core.Enums;
using SocialMedia.Core.Interfaces.Command;

namespace SocialMedia.Core.Services.Command
{
    public class PostCommandService : IPostCommandService
    {
        private readonly IPostCommandRepository _postCommandRepository;

        public PostCommandService(IPostCommandRepository postCommandRepository)
        {
            _postCommandRepository = postCommandRepository;
        }

        public async Task<SaveResource> AddPostAsync(AddPostDTO model)
        {
            return await _postCommandRepository.AddPostAsync(model);
        }

        public async Task<UpdateOrDeleteResource> UpdatePostAsync(UpdatePostDTO model)
        {
            return await _postCommandRepository.UpdatePostAsync(model);
        }

        public async Task<UpdateOrDeleteResource> DeletePostAsync(int postId)
        {
            return await _postCommandRepository.DeletePostAsync(postId);
        }
    }
}
