using Domain.Entities;

namespace Domain.Interfaces
{
  public interface ICommentRepository
  {
    Task<Comment> GetByIdAsync(Guid id);
    Task<IEnumerable<Comment>> GetByPostIdAsync(Guid postId);
    Task<IEnumerable<Comment>> GetByUserIdAsync(Guid userId);
    Task<IEnumerable<Comment>> GetRepliesAsync(Guid parentCommentId);
    Task<IEnumerable<Comment>> GetTopLevelCommentsAsync(Guid postId);
    Task AddAsync(Comment comment);
    Task UpdateAsync(Comment comment);
    Task DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
    Task<int> GetCommentCountAsync(Guid postId);
  }
}
