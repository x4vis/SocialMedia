using System.Threading.Tasks;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Enums;

namespace SocialMedia.Core.Interfaces.Command
{
    public interface IBaseCommandRepository<T> where T : BaseEntity
    {
        Task<WriteEntity> AddAsync(T entity);
        Task<WriteEntity> UpdateAsync(T entity);
        Task<WriteEntity> DeleteAsync(T entity);
    }
}
