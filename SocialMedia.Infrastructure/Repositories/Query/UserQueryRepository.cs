using SocialMedia.Infrastructure.Data.Context;
using System.Threading.Tasks;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces.Query;

namespace SocialMedia.Infrastructure.Repositories.Query
{
    public class UserQueryRepository : IUserQueryRepository
    {
        private readonly SocialMediaContext _context;

        public UserQueryRepository(SocialMediaContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }
    }
}
