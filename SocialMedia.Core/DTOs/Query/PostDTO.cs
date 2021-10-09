using System.Net.Mime;
using System;
using SocialMedia.Core.Entities;

namespace SocialMedia.Core.DTOs.Query
{
  public class PostDTO
  {
    public int PostId { get; set; }
    public int UserId { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }

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