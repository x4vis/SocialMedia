using SocialMedia.Core.DTOs.Query;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infrastructure.Mappers.Query
{
    public class PostMapper
    {
        public static PostDTO FromDataModel(Post model)
        {
            return model == null ? null : new PostDTO
            {
                PostId = model.PostId,
                UserId = model.UserId,
                Date = model.Date,
                Description = model.Description,
                Image = model.Image
            };
        }
    }
}
