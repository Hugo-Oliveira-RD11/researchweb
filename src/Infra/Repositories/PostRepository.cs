using Domain.Entities;
using Domain.Interfaces;

namespace Infra.Repositories;

public class PostRepository : IPostRepository
{
  public Task<Post>? GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

  public Task<IEnumerable<Post>>? GetByUserIdAsync(Guid userId)
    {
        return null;
    }

    //Task<IEnumerable<Post>> GetAllAsync(); // -> estou pensando se deixo mesmo
    public Task<IEnumerable<Post>>? GetRecentPostsAsync(int count)
    {
        return null;
    }

    public Task<IEnumerable<Post>>? GetPostsByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        return null;
    }

    public Task<IEnumerable<Post>>? Algorithm(Guid userId)
    {
        return null;
    }

    public Task AddAsync(Post post)
    {
      throw new NotImplementedException();
    }

    public Task? UpdateAsync(Post post)
    {
        return null;
    }

    public Task? DeleteAsync(Guid id)
    {
        return null;
    }

    public Task<bool>? ExistsAsync(Guid id)
    {
        return null;
    }

    public Task<int>? CountAsync()
    {
        return null;
    }
}
