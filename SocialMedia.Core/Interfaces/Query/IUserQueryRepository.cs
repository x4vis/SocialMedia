using System.Threading.Tasks;
using SocialMedia.Core.Entities;

namespace SocialMedia.Core.Interfaces.Query
{
    public interface IUserQueryRepository
    {
        Task<User> GetUserAsync(int id);
    }
}
