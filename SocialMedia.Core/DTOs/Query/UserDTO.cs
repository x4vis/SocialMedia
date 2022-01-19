using System;
using SocialMedia.Core.Entities;

namespace SocialMedia.Core.DTOs.Query
{
    public class UserDTO : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
