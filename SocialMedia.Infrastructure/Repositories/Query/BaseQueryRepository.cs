using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces.Query;
using SocialMedia.Infrastructure.Data.Context;

namespace SocialMedia.Infrastructure.Repositories.Query
{
    public class BaseQueryRepository<T> : IBaseQueryRepository<T> where T : BaseEntity
    {
        private readonly DbSet<T> _entity;

        public BaseQueryRepository(SocialMediaContext context)
        {
            _entity = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync(bool isTracked = false)
        {
            if (isTracked)
            {
                return await _entity.ToListAsync();
            }

            return await _entity
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id, bool isTracked = false)
        {
            if (isTracked)
            {
                return await _entity.FindAsync(id);
            }

            return await _entity
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
