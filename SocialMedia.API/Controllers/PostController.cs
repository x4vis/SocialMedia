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
        public async Task<ActionResult<IEnumerable<PostDTO>>> GetPosts()
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
        public async Task<ActionResult> AddPost(AddPostDTO dto)
        {
            var postAdded = await _postCommandService.AddPostAsync(dto);

            return postAdded switch
            {
                WriteEntity.Written => NoContent(),
                WriteEntity.NotWritten => StatusCode(500, "The post could not be written in the DB, please try again"),
                WriteEntity.Error => StatusCode(500, "The post could not be saved, please try again"),
                _ => StatusCode(500),
            };
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePost(UpdatePostDTO dto)
        {
            var postDTO = await _postQueryService.GetPostAsync(dto.Id);

            if (postDTO == null)
            {
                return NotFound();
            }

            var postUpdated = await _postCommandService.UpdatePostAsync(dto, postDTO);

            return postUpdated switch
            {
                UpdateOrDeleteResource.NotWritten => StatusCode(500, "The post could not be written in the DB, please try again"),
                UpdateOrDeleteResource.Error => StatusCode(500, "The post could not be updated, please try again"),
                UpdateOrDeleteResource.Written => Ok(),
                _ => StatusCode(500),
            };
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var postDeleted = await _postCommandService.DeletePostAsync(id);

            return postDeleted switch
            {
                UpdateOrDeleteResource.NotFound => NotFound(),
                UpdateOrDeleteResource.NotWritten => StatusCode(500, "The post could not be written in the DB, please try again"),
                UpdateOrDeleteResource.Error => StatusCode(500, "The post could not be deleted, please try again"),
                UpdateOrDeleteResource.Written => Ok(),
                _ => StatusCode(500),
            };
        }
    }
}