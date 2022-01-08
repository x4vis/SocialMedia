using System.Diagnostics;
using System;
using System.Threading.Tasks;
using SocialMedia.Core.Interfaces.Command;
using SocialMedia.Infrastructure.Data.Context;
using SocialMedia.Core.DTOs.Command;
using SocialMedia.Core.Enums;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infrastructure.Repositories.Commands
{
    public class PostCommandRepository : IPostCommandRepository
    {
        private readonly SocialMediaContext _context;

        public PostCommandRepository(SocialMediaContext context)
        {
            _context = context;
        }

        public async Task<int> AddPostAsync(Post model)
        {
            _context.Add(model);
            var rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected;
        }

        public async Task<UpdateOrDeleteResource> UpdatePostAsync(int postId, UpdatePostDTO model)
        {
            try
            {
                var currentPost = await _context.Posts.FindAsync(postId);

                if (currentPost == null)
                {
                    return UpdateOrDeleteResource.NotFound;
                }

                currentPost.Date = model.Date;
                currentPost.Description = model.Description;
                currentPost.Image = model.Image;

                int rowsAffected = await _context.SaveChangesAsync();
                return rowsAffected > 0 ? UpdateOrDeleteResource.Written : UpdateOrDeleteResource.NotWritten;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error has ocurred while updating the post {ex}");
                return UpdateOrDeleteResource.Error;
            }
        }

        public async Task<UpdateOrDeleteResource> DeletePostAsync(int postId)
        {
            try
            {
                var currentPost = await _context.Posts.FindAsync(postId);

                if (currentPost == null)
                {
                    return UpdateOrDeleteResource.NotFound;
                }

                _context.Posts.Remove(currentPost);

                int rowsAffected = await _context.SaveChangesAsync();
                return rowsAffected > 0 ? UpdateOrDeleteResource.Written : UpdateOrDeleteResource.NotWritten;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error has ocurred while updating the post {ex}");
                return UpdateOrDeleteResource.Error;
            }

        }
    }
}