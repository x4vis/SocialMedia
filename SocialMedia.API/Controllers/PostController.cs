using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.DTOs.Command;
using SocialMedia.Core.DTOs.Query;
using SocialMedia.Core.Enums;
using SocialMedia.Core.Interfaces.Command;
using SocialMedia.Core.Interfaces.Query;

namespace SocialMedia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostCommandService _postCommandService;
        private readonly IPostQueryRepository _postQueryRepository;

        public PostController
        (
            IPostCommandService postCommandService,
            IPostQueryRepository postQueryRepository
        )
        {
            _postCommandService = postCommandService;
            _postQueryRepository = postQueryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDTO>>> GetPosts()
        {
            var posts = await _postQueryRepository.GetPostsAsync();
            return Ok(posts);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PostDTO>> GetPost(int id)
        {
            var post = await _postQueryRepository.GetPostAsync(id);

            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpPost]
        public async Task<ActionResult> AddPost(AddPostDTO model)
        {
            var postAdded = await _postCommandService.AddPostAsync(model);

            switch (postAdded)
            {
                case SaveResource.NotSaved:
                    return StatusCode(500, "The post could not be written in the DB, please try again");
                case SaveResource.Error:
                    return StatusCode(500, "The post could not be saved, please try again");
                default:
                    return NoContent();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePost(int postId, UpdatePostDTO model)
        {
            var postUpdated = await _postCommandService.UpdatePostAsync(postId, model);

            switch (postUpdated)
            {
                case UpdateOrDeleteResource.NotFound:
                    return NotFound();
                case UpdateOrDeleteResource.NotWritten:
                    return StatusCode(500, "The post could not be written in the DB, please try again");
                case UpdateOrDeleteResource.Error:
                    return StatusCode(500, "The post could not be updated, please try again");
                default:
                    return NoContent();
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var postDeleted = await _postCommandService.DeletePostAsync(id);

            switch (postDeleted)
            {
                case UpdateOrDeleteResource.NotFound:
                    return NotFound();
                case UpdateOrDeleteResource.NotWritten:
                    return StatusCode(500, "The post could not be written in the DB, please try again");
                case UpdateOrDeleteResource.Error:
                    return StatusCode(500, "The post could not be deleted, please try again");
                default:
                    return Ok();
            }
        }
    }
}