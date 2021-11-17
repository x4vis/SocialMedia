using System.Collections.Generic;
using SocialMedia.Core.Interfaces.Query;
using System.Threading.Tasks;
using SocialMedia.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using SocialMedia.Core.DTOs.Query;
using SocialMedia.Infrastructure.Mappers.Query;

namespace SocialMedia.Infrastructure.Repositories.Query
{
    public class PostRepositoryQuery : IPostRepositoryQuery
    {
        private readonly SocialMediaContext _context;

        public PostRepositoryQuery(SocialMediaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PostDTO>> GetPosts()
        {
            var query = _context.Posts;
            var list = await query
            .Select(e => PostMapper.FromDataModel(e))
            .ToListAsync();

            return list;
        }

        public async Task<PostDTO> GetPost(int id)
        {
            var query = _context.Posts;
            var post = await query.FindAsync(id);

            return PostMapper.FromDataModel(post);
        }
    }
}