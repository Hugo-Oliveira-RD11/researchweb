// src/Infra/Repositories/UserRepository.cs
using Microsoft.EntityFrameworkCore;
using reasearchweb.Application.Interfaces;
using reasearchweb.Domain.Entities;
using reasearchweb.Infra.Data;
using reasearchweb.Infra.Data.Entities;

namespace reasearchweb.Infra.Repositories;

public class UserRepository : IUserRepository
{
  private readonly ApplicationDbContext _context;

  public UserRepository(ApplicationDbContext context)
  {
    _context = context;
  }

  public async Task<User> GetByIdAsync(Guid id)
  {
    var entity = await _context.Users.FindAsync(id);
    return entity == null ? null : ToDomain(entity);
  }

  public async Task<User> GetByEmailAsync(string email)
  {
    var entity = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    return entity == null ? null : ToDomain(entity);
  }

  public async Task<User> GetByUsernameAsync(string username)
  {
    var entity = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
    return entity == null ? null : ToDomain(entity);
  }

  public async Task AddAsync(User user)
  {
    var entity = ToEntity(user);
    await _context.Users.AddAsync(entity);
    await _context.SaveChangesAsync();

  }

  public async Task UpdateAsync(User user)
  {
    var entity = ToEntity(user);
    _context.Users.Update(entity);
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

  public async Task<User> GetByUsernameOrEmailAsync(string usernameOrEmail)
  {
    throw new NotImplementedException();
  }
  private User ToDomain(UserEntity entity)
  {
    return new User(
      entity.Username,
      entity.Email,
      entity.PasswordHash,
      entity.BirthDate)
    {
      Id = entity.Id,
      ProfilePictureUrl = entity.ProfilePictureUrl,
      CreatedAt = entity.CreatedAt 
    };
  }

  private UserEntity ToEntity(User domain)
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
