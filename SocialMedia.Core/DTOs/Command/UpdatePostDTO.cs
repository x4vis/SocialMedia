﻿using System;
namespace SocialMedia.Core.DTOs.Command
{
    public class UpdatePostDTO
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
