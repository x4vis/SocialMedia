using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.DTOs.Query;
using SocialMedia.Core.Interfaces.Command;
using SocialMedia.Core.Interfaces.Query;

namespace SocialMedia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
    private readonly IPostRepositoryQuery _repositoryQuery;
    private readonly IPostRepositoryCommand _repositoryCommand;

    public PostController(
        IPostRepositoryQuery repositoryQuery,
        IPostRepositoryCommand repositoryCommand
    )
    {
        _repositoryQuery = repositoryQuery;
        _repositoryCommand = repositoryCommand;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PostDTO>>> GetPosts()
    {
        var posts = await _repositoryQuery.GetPosts();
        return Ok(posts);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<PostDTO>> GetPost(int id)
    {
        var post = await _repositoryQuery.GetPost(id);

        if (post == null)
        {
        return NotFound();
        }
        return Ok(post);
    }

    [HttpPost]
    public async Task<ActionResult<PostDTO>> AddPost(PostDTO model)
    {
        var added = await _repositoryCommand.AddPost(model);

        if (added == -1)
        {
        return StatusCode(500);
        }

        return Ok(model);
    }
    }
}