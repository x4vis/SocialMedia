using SocialMedia.Core.DTOs.Query;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infrastructure.Mappers.Query
{
    public class PostMapper
    {
        public static PostDTO FromDataModel(Post entity)
        {
            return entity == null ? null : new PostDTO
            {
                PostId = entity.PostId,
                UserId = entity.UserId,
                Date = entity.Date,
                Description = entity.Description,
                Image = entity.Image
            };
        }
    }
}
