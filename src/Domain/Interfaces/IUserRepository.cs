using reasearchweb.Domain.Entities;

namespace reasearchweb.Application.Interfaces;

public interface IUserRepository
{
  Task<User> GetByIdAsync(Guid id);
  Task<User> GetByEmailAsync(string email);
  Task<User> GetByUsernameAsync(string username);
  Task<User> GetByUsernameOrEmailAsync(string usernameOrEmail);
  Task AddAsync(User user);
  Task UpdateAsync(User user);
  Task DeleteAsync(User user);
  Task<bool> ExistsByEmailAsync(string email);
  Task<bool> ExistsByUsernameAsync(string username);
}
