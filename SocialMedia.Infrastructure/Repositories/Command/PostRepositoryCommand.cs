using System.Diagnostics;
using System;
using System.Threading.Tasks;
using SocialMedia.Core.Interfaces.Command;
using SocialMedia.Infrastructure.Data.Context;
using SocialMedia.Core.DTOs.Command;
using SocialMedia.Infrastructure.Mappers.Command;

namespace SocialMedia.Infrastructure.Repositories.Commands
{
    public class PostRepositoryCommand : IPostRepositoryCommand
    {
        private readonly SocialMediaContext _context;

        public PostRepositoryCommand(SocialMediaContext context)
        {
            _context = context;
        }

        public async Task<int> AddPost(AddPostDTO model)
        {
            var saved = 0;

            try
            {
                var dataModel = AddPostMapper.ToDataModel(model);
                _context.Add(dataModel);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                saved = -1;
                Debug.WriteLine($"An error has ocurred while adding a post ==> {ex}");
            }

            return saved;
        }
    }
}