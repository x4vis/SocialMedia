using System.Diagnostics;
using System;
using System.Threading.Tasks;
using SocialMedia.Core.Interfaces.Command;
using SocialMedia.Infrastructure.Data.Context;
using SocialMedia.Core.DTOs.Query;

namespace SocialMedia.Infrastructure.Repositories.Commands
{
  public class PostRepositoryCommand : IPostRepositoryCommand
  {
    private readonly IPostRepositoryCommand _repository;
    private readonly SocialMediaContext _context;

    public PostRepositoryCommand(
      SocialMediaContext context,
      IPostRepositoryCommand repository
    )
    {
      _context = context;
      _repository = repository;
    }

    public SocialMediaContext Context { get; }

    public async Task<int> AddPost(PostDTO model)
    {
      var saved = 0;

      try
      {
        _context.Add(model);
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