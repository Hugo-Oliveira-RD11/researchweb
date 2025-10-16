using Domain.Entities;
using Domain.Interfaces;
using Infra.Data;
using Microsoft.EntityFrameworkCore;
using Infra.Data.Entities;

namespace Infra.Repositories;

public class UserRepository : IUserRepository
{
  private readonly ApplicationDbContext _context;

  public UserRepository(ApplicationDbContext context)
  {
    _context = context;
  }

  public async Task<User?> GetByIdAsync(Guid id)
  {
    var entity = await _context.Users.FindAsync(id);
    return entity == null ? null : ToDomain(entity);
  }

  public async Task<User?> GetByEmailAsync(string email)
  {
    var entity = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    return entity == null ? null : ToDomain(entity);
  }

  public async Task<User?> GetByUsernameAsync(string username)
  {
    var entity = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
    return entity == null ? null : ToDomain(entity);
  }

  public async Task<User?> GetByUsernameOrEmailAsync(string usernameOrEmail)
  {
    var entity = await _context.Users
      .FirstOrDefaultAsync(u => u.Username == usernameOrEmail || u.Email == usernameOrEmail);

    return entity == null ? null : ToDomain(entity);
  }

  public async Task AddAsync(User user)
  {
    var entity = ToEntity(user);
    await _context.Users.AddAsync(entity);
    await _context.SaveChangesAsync();

    // Atualiza o ID gerado no domínio
    user.Id = entity.Id;
  }

  public async Task UpdateAsync(User user)
  {
    var entity = ToEntity(user);
    _context.Users.Update(entity);
    await _context.SaveChangesAsync();
  }

  public async Task DeleteAsync(User user)
  {
    var entity = ToEntity(user);
    _context.Users.Remove(entity);
    await _context.SaveChangesAsync();
  }

  public async Task<bool> ExistsByEmailAsync(string email)
  {
    return await _context.Users.AnyAsync(u => u.Email == email);
  }

  public async Task<bool> ExistsByUsernameAsync(string username)
  {
    return await _context.Users.AnyAsync(u => u.Username == username);
  }

  private User ToDomain(UserEntity entity)
  {
    return new User(username: entity.Username, email: entity.Email, passwordHash:entity.PasswordHash, birthDate: entity.BirthDate)
    {
      Id = entity.Id,
        ProfilePictureUrl = entity.ProfilePictureUrl,
        CreatedAt = entity.CreatedAt
        };
  }

  public UserEntity ToEntity(User domain)
  {
    return new UserEntity
    {
      Id = domain.Id,
      Username = domain.Username,
      Email = domain.Email,
      PasswordHash = domain.PasswordHash,
      BirthDate = domain.BirthDate,
      ProfilePictureUrl = domain.ProfilePictureUrl,
      CreatedAt = domain.CreatedAt
    };
  }
}
