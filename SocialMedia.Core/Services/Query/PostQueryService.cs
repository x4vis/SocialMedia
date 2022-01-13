using System.Collections.Generic;
using System.Threading.Tasks;
using SocialMedia.Core.DTOs.Query;
using SocialMedia.Core.Interfaces.Query;

namespace SocialMedia.Core.Services.Query
{
    public class PostQueryService : IPostQueryService
    {
        private readonly IPostQueryService _postQueryRepository;

        public PostQueryService(IPostQueryService postQueryRepository)
        {
            _postQueryRepository = postQueryRepository;
        }

        public async Task<PostDTO> GetPostAsync(int id)
        {
            return await _postQueryRepository.GetPostAsync(id);
        }

        public async Task<List<PostDTO>> GetPostsAsync()
        {
            return await _postQueryRepository.GetPostsAsync();
        }
    }
}
