using System;
using System.Threading.Tasks;
using SocialMedia.Core.DTOs.Command;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Enums;
using SocialMedia.Core.Interfaces.Command;
using SocialMedia.Core.Interfaces.Query;
using SocialMedia.Core.Mappers.Command;

namespace SocialMedia.Core.Services.Command
{
    public class PostCommandService : IPostCommandService
    {
        private readonly IBaseCommandRepository<Post> _postCommandRepository;
        private readonly IBaseQueryRepository<Post> _postQueryRepository;
        private readonly IBaseQueryRepository<User> _userQueryRepository;

        public PostCommandService
            (
                IBaseCommandRepository<Post> postCommandRepository,
                IBaseQueryRepository<User> userQueryRepository,
                IBaseQueryRepository<Post> postQueryRepository
            )
        {
            _postCommandRepository = postCommandRepository;
            _userQueryRepository = userQueryRepository;
            _postQueryRepository = postQueryRepository;
        }

        public async Task<WriteEntity> AddPostAsync(AddPostDTO dto)
        {
            var user = await _userQueryRepository.GetByIdAsync(dto.UserId);

            if (user == null)
            {
                throw new Exception("User does not exists");
            }

            var description = dto.Description.ToLower();

            if (description.Contains("sexo"))
            {
                throw new Exception("Content not allowed");
            }

            var model = AddPostCommandMapper.ToDataModel(dto);
            return await _postCommandRepository.AddAsync(model);
        }

        public async Task<WriteEntity> UpdatePostAsync(UpdatePostDTO dto)
        {
            var post = await _postQueryRepository.GetByIdAsync(dto.Id, true);

            post.Date = dto.Date;
            post.Description = dto.Description;
            post.Image = post.Image;

            return await _postCommandRepository.UpdateAsync(post);
        }

        public async Task<WriteEntity> DeletePostAsync(int postId)
        {
            var post = await _postQueryRepository.GetByIdAsync(postId, true);
            return await _postCommandRepository.DeleteAsync(post);
        }
    }
}
