using System;
using SocialMedia.Core.Entities;

namespace SocialMedia.Core.DTOs.Command
{
    public class AddPostDTO : BaseEntity
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}