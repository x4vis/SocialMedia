using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.DTOs.Command;
using SocialMedia.Core.DTOs.Query;
using SocialMedia.Core.Interfaces.Command;
using SocialMedia.Core.Interfaces.Query;

namespace SocialMedia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostRepositoryQuery _postRepositoryQuery;
        private readonly IPostRepositoryCommand _postRepositoryCommand;

        public PostController
        (
            IPostRepositoryQuery postRepositoryquery,
            IPostRepositoryCommand repositoryCommand
        )
        {
            _postRepositoryQuery = postRepositoryquery;
            _postRepositoryCommand = repositoryCommand;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDTO>>> GetPosts()
        {
            var posts = await _postRepositoryQuery.GetPosts();
            return Ok(posts);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PostDTO>> GetPost(int id)
        {
            var post = await _postRepositoryQuery.GetPost(id);

            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpPost]
        public async Task<ActionResult<PostDTO>> AddPost(AddPostDTO model)
        {
            var added = await _postRepositoryCommand.AddPost(model);

            if (added == -1)
            {
                return StatusCode(500);
            }

            return Ok();
        }
    }
}