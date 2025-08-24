namespace reasearchweb.Domain.Entities;

public class User
{
  public Guid Id { get; set; } = Guid.NewGuid();
  public string Username { get; private set; }
  public string Email { get; private set; }
  public string PasswordHash { get; private set; }
  public DateOnly BirthDate { get; private set; }
  public string? ProfilePictureUrl { get;  set; }
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

  public User(string username, string email, string passwordHash, DateOnly birthDate)
  {
    Username = username;
    Email = email;
    PasswordHash = passwordHash;
    BirthDate = birthDate;
  }

  private User() { }

  public void UpdateId(Guid id)
  {
    Id = id;
  }
  public void UpdateProfilePicture(string url)
  {
    ProfilePictureUrl = url;
  }
}
