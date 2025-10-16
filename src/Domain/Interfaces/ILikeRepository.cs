using Domain.Entities;

namespace Domain.Interfaces
{
  public interface ILikeRepository
  {
    Task<Like> GetByIdAsync(Guid id);
    Task<Like> GetByUserAndPostAsync(Guid userId, Guid postId);
    Task<IEnumerable<Like>> GetByPostIdAsync(Guid postId);
    Task<IEnumerable<Like>> GetByUserIdAsync(Guid userId);
    Task<int> GetLikesCountAsync(Guid postId);
    Task<int> GetDislikesCountAsync(Guid postId);
    Task AddAsync(Like like);
    Task ChangeLikeAsync(Like like);
    Task DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
    Task<bool> UserHasLikedPostAsync(Guid userId, Guid postId);
  }
}
