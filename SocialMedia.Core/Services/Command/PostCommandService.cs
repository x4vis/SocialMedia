using System;
using System.Diagnostics;
using System.Threading.Tasks;
using SocialMedia.Core.DTOs.Command;
using SocialMedia.Core.Enums;
using SocialMedia.Core.Interfaces.Command;
using SocialMedia.Core.Mappers.Command;

namespace SocialMedia.Core.Services.Command
{
    public class PostCommandService : IPostCommandService
    {
        private readonly IPostCommandRepository _postCommandRepository;

        public PostCommandService(IPostCommandRepository postCommandRepository)
        {
            _postCommandRepository = postCommandRepository;
        }

        public async Task<SaveResource> AddPostAsync(AddPostDTO model)
        {
            try
            {
                var dataModel = PostCommandMapper.ToDataModel(model);
                var rowsAffected = await _postCommandRepository.AddPostAsync(dataModel);
                return rowsAffected > 0 ? SaveResource.Saved : SaveResource.NotSaved;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error has ocurred while adding a post ==> {ex}");
                return SaveResource.Error;
            }
        }
    }
}
