using SocialMedia.Core.DTOs.Query;
using SocialMedia.Core.Entities;

namespace SocialMedia.Core.Mappers.Query
{
    public class PostQueryMapper
    {
        public static PostDTO FromDataModel(Post model)
        {
            return model == null ? null : new PostDTO
            {
                Id = model.Id,
                UserId = model.UserId,
                Date = model.Date,
                Description = model.Description,
                Image = model.Image
            };
        }
    }
}
