using reasearchweb.Domain.Entities;

namespace ResearchWeb.Domain.Interfaces
{
  public interface IPostRepository
  {
    Task<Post> GetByIdAsync(Guid id);
    Task<IEnumerable<Post>> GetByUserIdAsync(Guid userId);
    Task<IEnumerable<Post>> GetAllAsync(); // -> estou pensando se deixo mesmo
    Task<IEnumerable<Post>> GetRecentPostsAsync(int count);
    Task<IEnumerable<Post>> GetPostsByDateRangeAsync(DateTime startDate, DateTime endDate);
    Task<IEnumerable<Post>> Algorithm(Guid userId);
    Task AddAsync(Post post);
    Task UpdateAsync(Post post);
    Task DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
    Task<int> CountAsync();
  }
}
