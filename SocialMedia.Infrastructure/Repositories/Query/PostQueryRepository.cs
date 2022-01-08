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

        public async Task<IEnumerable<PostDTO>> GetPostsAsync()
        {
            var query = _context.Posts;
            var list = await query
                .AsNoTracking()
                .Select(e => PostQueryMapper.FromDataModel(e))
                .ToListAsync();

            return list;
        }

        public async Task<PostDTO> GetPostAsync(int id)
        {
            var query = _context.Posts;
            var post = await query.FindAsync(id);

            return PostQueryMapper.FromDataModel(post);
        }
    }
}