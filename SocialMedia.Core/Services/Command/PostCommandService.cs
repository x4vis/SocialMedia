using System;
using System.Threading.Tasks;
using SocialMedia.Core.DTOs.Command;
using SocialMedia.Core.Enums;
using SocialMedia.Core.Interfaces.Command;
using SocialMedia.Core.Interfaces.Query;

namespace SocialMedia.Core.Services.Command
{
    public class PostCommandService : IPostCommandService
    {
        private readonly IPostCommandRepository _postCommandRepository;
        private readonly IUserQueryRepository _userQueryRepository;

        public PostCommandService
            (
                IPostCommandRepository postCommandRepository,
                IUserQueryRepository userQueryRepository
            )
        {
            _postCommandRepository = postCommandRepository;
            _userQueryRepository = userQueryRepository;
        }

        public async Task<WriteEntity> AddPostAsync(AddPostDTO model)
        {
            var user = await _userQueryRepository.GetUserAsync(model.Id);

            if (user == null)
            {
                throw new Exception("User does not exists");
            }

            var description = model.Description.ToLower();

            if (description.Contains("sexo"))
            {
                throw new Exception("Content not allowed");
            }

            return await _postCommandRepository.AddPostAsync(model);
        }

        public async Task<WriteEntity> UpdatePostAsync(UpdatePostDTO model)
        {
            return await _postCommandRepository.UpdatePostAsync(model);
        }

        public async Task<WriteEntity> DeletePostAsync(int postId)
        {
            return await _postCommandRepository.DeletePostAsync(postId);
        }
    }
}
