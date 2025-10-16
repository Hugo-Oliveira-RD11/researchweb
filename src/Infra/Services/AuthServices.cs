using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Services;
using Microsoft.IdentityModel.Tokens;

namespace researchweb.Infra.Services;

public class AuthService : IAuthService
{
  private readonly string _jwtSecret;
  private readonly int _jwtExpirationInMinutes;

  public AuthService(string jwtSecret, int jwtExpirationInMinutes)
  {
    _jwtSecret = jwtSecret;
    _jwtExpirationInMinutes = jwtExpirationInMinutes;
  }

  public string HashPassword(string password)
  {
    return BCrypt.Net.BCrypt.HashPassword(password, workFactor: 12);
  }

  public bool VerifyPassword(string password, string hashedPassword)
  {
    return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
  }

  public string GenerateJwtToken(Guid userId, string username)
  {
    var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.ASCII.GetBytes(_jwtSecret);

    var tokenDescriptor = new SecurityTokenDescriptor
    {
      Subject = new ClaimsIdentity(new[]
      {
        new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
        new Claim(ClaimTypes.Name, username)
      }),
      Expires = DateTime.UtcNow.AddMinutes(_jwtExpirationInMinutes),
      SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
    };

    var token = tokenHandler.CreateToken(tokenDescriptor);
    return tokenHandler.WriteToken(token);
  }
}
