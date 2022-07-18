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

        public async Task<Response<IEnumerable<PostDTO>>> GetPostsAsync()
        {
            try
            {
                var posts = await _postQueryRepository.GetAllAsync();
                var postsDTO = posts.Select(p => PostQueryMapper.FromDataModel(p));

                if (postsDTO == null)
                {
                    postsDTO = Enumerable.Empty<PostDTO>();
                }

                return APIResponseMapper<IEnumerable<PostDTO>>
                    .BuildResponse(true, postsDTO);
            }
            catch (Exception ex)
            {
                return APIResponseMapper<IEnumerable<PostDTO>>
                    .BuildResponse(false, null, ex.Message);
            }
        }

        public async Task<Response<PostDTO>> GetPostAsync(int id)
        {
            try
            {
                var post = await _postQueryRepository.GetByIdAsync(id);
                var postDTO = PostQueryMapper.FromDataModel(post);

                if (postDTO == null)
                {
                    postDTO = new PostDTO();
                }

                return APIResponseMapper<PostDTO>
                    .BuildResponse(true, postDTO);
            }
            catch (Exception ex)
            {
                return APIResponseMapper<PostDTO>
                    .BuildResponse(false, null, ex.Message);
            }
        }
    }
}
