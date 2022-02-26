using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        private HttpStatusCode httpStatusCode;

        public PostQueryService(IBaseQueryRepository<Post> postQueryRepository)
        {
            _postQueryRepository = postQueryRepository;
            httpStatusCode = HttpStatusCode.OK;
        }

        public async Task<APIResponse<IEnumerable<PostDTO>>> GetPostsAsync()
        {
            try
            {
                var posts = await _postQueryRepository.GetAllAsync();
                var postsDTO = posts.Select(p => PostQueryMapper.FromDataModel(p));
                                
                if (postsDTO == null)
                {
                    httpStatusCode = HttpStatusCode.NotFound;
                }
                
                return APIResponseMapper<IEnumerable<PostDTO>>
                    .BuildResponse(postsDTO == null, httpStatusCode, postsDTO);
            }
            catch (Exception ex)
            {
                httpStatusCode = HttpStatusCode.InternalServerError;
                return APIResponseMapper<IEnumerable<PostDTO>>
                    .BuildResponse(false, httpStatusCode, null, ex.Message);
            }
        }

        public async Task<APIResponse<PostDTO>> GetPostAsync(int id)
        {
            try
            {
                var post = await _postQueryRepository.GetByIdAsync(id);
                var postDTO = PostQueryMapper.FromDataModel(post);

                if (postDTO == null)
                {
                    httpStatusCode = HttpStatusCode.NotFound;
                }

                return APIResponseMapper<PostDTO>
                    .BuildResponse(true, httpStatusCode, postDTO);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
