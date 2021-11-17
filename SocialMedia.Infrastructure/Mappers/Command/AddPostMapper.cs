using SocialMedia.Core.DTOs.Command;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infrastructure.Mappers.Command
{
    public class AddPostMapper
    {
        public static Post ToDataModel(AddPostDTO dto)
        {
            return dto == null ? null : new Post
            {
                UserId = dto.UserId,
                Date = dto.Date,
                Description = dto.Description,
                Image = dto.Image
            };
        }
    }
}
