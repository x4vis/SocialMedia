using System.Collections.Generic;
using SocialMedia.Core.Interfaces.Query;
using System.Threading.Tasks;
using SocialMedia.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using SocialMedia.Core.DTOs.Query;
using SocialMedia.Core.Mappers.Query;

namespace SocialMedia.Infrastructure.Repositories.Query
{
    public class PostQueryRepository : IPostQueryRepository
    {
        private readonly SocialMediaContext _context;

        public PostQueryRepository(SocialMediaContext context)
        {
            _context = context;
        }

        public async Task<List<PostDTO>> GetPostsAsync()
        {
            var query = _context.Posts
                .AsNoTracking()
                .Select(e => PostQueryMapper.FromDataModel(e));

            var list = await query.ToListAsync();

            return list;
        }

        public async Task<PostDTO> GetPostAsync(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            return PostQueryMapper.FromDataModel(post);
        }
    }
}