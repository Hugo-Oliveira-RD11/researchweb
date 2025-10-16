namespace Application.Services;

public interface IAuthService
{
  string HashPassword(string password);
  bool VerifyPassword(string password, string hashedPassword);
  string GenerateJwtToken(Guid userId, string username);
}
