using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Enums;
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

        public async Task<WriteEntity> AddAsync(T entity)
        {
            try
            {
                _context.Add(entity);
                var rowsAffected = await _context.SaveChangesAsync();
                return rowsAffected > 0 ? WriteEntity.Written : WriteEntity.NotWritten;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error has ocurred while adding the entity ==> {ex}");
                return WriteEntity.Error;
            }
        }

        public async Task<WriteEntity> UpdateAsync(T entity)
        {
            try
            {
                _entity.Update(entity);
                var rowsAffected = await _context.SaveChangesAsync();
                return rowsAffected > 0 ? WriteEntity.Written : WriteEntity.NotWritten;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error has ocurred while updating the entity {ex}");
                return WriteEntity.Error;
            }
        }

        public async Task<WriteEntity> DeleteAsync(T entity)
        {
            try
            {
                _entity.Remove(entity);
                int rowsAffected = await _context.SaveChangesAsync();
                return rowsAffected > 0 ? WriteEntity.Written : WriteEntity.NotWritten;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error has ocurred while updating the entity {ex}");
                return WriteEntity.Error;
            }

        }

    }
}
