using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.DTOs.Query;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces.Query;
using SocialMedia.Core.Mappers;
using SocialMedia.Core.Mappers.Query;

namespace SocialMedia.Core.Services.Query
{
    public class PostQueryService : IPostQueryService
    {
        private readonly IBaseQueryRepository<Post> _postQueryRepository;

        public PostQueryService(IBaseQueryRepository<Post> postQueryRepository)
        {
            _postQueryRepository = postQueryRepository;
        }

        public async Task<APIResponse<IEnumerable<PostDTO>>> GetPostsAsync()
        {
            try
            {
                var posts = await _postQueryRepository.GetAllAsync();

                if (posts == null)
                {
                    return APIResponseMapper<IEnumerable<PostDTO>>
                        .BuildResponse(false, "204", null);
                }

                posts.Select(p => PostQueryMapper.FromDataModel(p));
            }
            catch (Exception ex)
            {
                return APIResponseMapper<IEnumerable<PostDTO>>
                    .BuildResponse(false, "204", null, ex.Message);
            }
        }

        public async Task<APIResponse<PostDTO>> GetPostAsync(int id)
        {
            try
            {
                var post = await _postQueryRepository.GetByIdAsync(id);
                return PostQueryMapper.FromDataModel(post);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
