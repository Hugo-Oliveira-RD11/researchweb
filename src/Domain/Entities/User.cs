namespace reasearchweb.Domain.Entities;

public class User
{
  public Guid Id { get; private set; } = Guid.NewGuid();
  public string Username { get; private set; }
  public string Email { get; private set; }
  public string PasswordHash { get; private set; }
  public DateTime BirthDate { get; private set; }
  public string? ProfilePictureUrl { get; private set; }
  public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
  public DateOnly BirthDate { get; private set; }

  public User(string username, string email, string passwordHash, DateTime birthDate)
  {
    Username = username;
    Email = email;
    PasswordHash = passwordHash;
    BirthDate = birthDate;
  }

  private User() { }

  public void UpdateProfilePicture(string url)
  {
    ProfilePictureUrl = url;
  }
}
