using SocialMedia.Core.DTOs.Command;
using SocialMedia.Core.Entities;

namespace SocialMedia.Core.Mappers.Command
{
    public class PostCommandMapper
    {
        public static Post ToDataModel(AddPostDTO dto)
        {
            return dto == null ? null : new Post
            {
                Id = dto.Id,
                Date = dto.Date,
                Description = dto.Description,
                Image = dto.Image
            };
        }
    }
}
