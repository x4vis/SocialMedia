using SocialMedia.Core.DTOs.Query;
using SocialMedia.Core.Entities;

namespace SocialMedia.Core.Mappers.Query
{
    public class UserQueryMapper
    {
        public static UserDTO FromDataModel(User model)
        {
            return model == null ? null : new UserDTO
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                DateOfBirth = model.DateOfBirth,
                PhoneNumber = model.PhoneNumber,
                IsActive = model.IsActive
            };
        }
    }
}
