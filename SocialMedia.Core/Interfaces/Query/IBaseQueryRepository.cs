using System.Collections.Generic;
using System.Threading.Tasks;
using SocialMedia.Core.Entities;

namespace SocialMedia.Core.Interfaces.Query
{
    public interface IBaseQueryRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync(bool isTracked = false);
        Task<T> GetByIdAsync(int id, bool isTracked = false);
    }
}
