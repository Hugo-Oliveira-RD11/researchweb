using reasearchweb.Application.DTOs;
using reasearchweb.Application.Interfaces;
using reasearchweb.Application.Services;
using reasearchweb.Domain.Entities;

namespace reasearchweb.Application.UseCases;

public class UserUseCases
{
  private readonly IUserRepository _userRepository;
  private readonly IAuthService _authService;

  public UserUseCases(IUserRepository userRepository, IAuthService authService)
  {
    _userRepository = userRepository;
    _authService = authService;
  }

  public async Task<UserDto> CreateUserAsync(CreateUserDto createUserDto)
  {
    // Verificar se o email já existe
    if (await _userRepository.ExistsByEmailAsync(createUserDto.Email))
      throw new ArgumentException("Email already exists");

    // Verificar se o username já existe
    if (await _userRepository.ExistsByUsernameAsync(createUserDto.Username))
      throw new ArgumentException("Username already exists");

    // Hash da senha
    var passwordHash = _authService.HashPassword(createUserDto.Password);

    // Criar usuário
    var user = new User(
      createUserDto.Username,
      createUserDto.Email,
      passwordHash,
      createUserDto.BirthDate
    );

    await _userRepository.AddAsync(user);

    return new UserDto
    {
      Id = user.Id,
      Username = user.Username,
      Email = user.Email,
      BirthDate = user.BirthDate,
      ProfilePictureUrl = user.ProfilePictureUrl,
      CreatedAt = user.CreatedAt
    };
  }

  public async Task<string> AuthenticateUserAsync(string email, string password)
  {
    var user = await _userRepository.GetByEmailAsync(email);
    if (user == null || !_authService.VerifyPassword(password, user.PasswordHash))
      throw new UnauthorizedAccessException("Invalid credentials");

    return _authService.GenerateJwtToken(user.Id, user.Username);
  }

  public async Task<UserDto> GetUserByIdAsync(Guid id)
  {
    var user = await _userRepository.GetByIdAsync(id);
    if (user == null)
      throw new KeyNotFoundException("User not found");

    return new UserDto
    {
      Id = user.Id,
      Username = user.Username,
      Email = user.Email,
      BirthDate = user.BirthDate,
      ProfilePictureUrl = user.ProfilePictureUrl,
      CreatedAt = user.CreatedAt
    };
  }

  public async Task UpdateUserProfilePictureAsync(Guid userId, string profilePictureUrl)
  {
    var user = await _userRepository.GetByIdAsync(userId);
    if (user == null)
      throw new KeyNotFoundException("User not found");

    user.UpdateProfilePicture(profilePictureUrl);
    await _userRepository.UpdateAsync(user);
  }
}
