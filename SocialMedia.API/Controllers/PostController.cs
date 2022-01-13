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
        private readonly IPostQueryService _postQueryService;

        public PostController
        (
            IPostCommandService postCommandService,
            IPostQueryService postQueryService
        )
        {
            _postCommandService = postCommandService;
            _postQueryService = postQueryService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<PostDTO>>> GetPosts()
        {
            var posts = await _postQueryService.GetPostsAsync();
            return Ok(posts);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PostDTO>> GetPost(int id)
        {
            var post = await _postQueryService.GetPostAsync(id);

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
                case SaveResource.Saved:
                    return NoContent();
                default:
                    return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePost(UpdatePostDTO model)
        {
            var postUpdated = await _postCommandService.UpdatePostAsync(model);

            switch (postUpdated)
            {
                case UpdateOrDeleteResource.NotFound:
                    return NotFound();
                case UpdateOrDeleteResource.NotWritten:
                    return StatusCode(500, "The post could not be written in the DB, please try again");
                case UpdateOrDeleteResource.Error:
                    return StatusCode(500, "The post could not be updated, please try again");
                case UpdateOrDeleteResource.Written:
                    return Ok();
                default:
                    return StatusCode(500);
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
                case UpdateOrDeleteResource.Written:
                    return Ok();
                default:
                    return StatusCode(500);
            }
        }
    }
}