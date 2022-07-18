using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces.Command;
using SocialMedia.Infrastructure.Data.Context;

namespace SocialMedia.Infrastructure.Repositories.Command
{
    public class BaseCommandRepository<T> : IBaseCommandRepository<T> where T : BaseEntity
    {
        private readonly SocialMediaContext _context;
        private readonly DbSet<T> _entity;

        public BaseCommandRepository(SocialMediaContext context)
        {
            _context = context;
            _entity = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _entity.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _entity.Remove(entity);
            await _context.SaveChangesAsync();
        }

    }
}
