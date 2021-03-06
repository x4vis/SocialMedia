using System;
using SocialMedia.Core.Entities;

namespace SocialMedia.Core.DTOs.Query
{
    public class PostDTO : BaseEntity
    {
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}