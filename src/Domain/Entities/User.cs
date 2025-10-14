
namespace reasearchweb.Domain.Entities;

public class User : BaseEntity
{
  public string Username { get;  set; }
  public string Email { get;  set; }
  public string PasswordHash { get; set; }
  public DateOnly? BirthDate { get;  set; }
  public string? ProfilePictureUrl { get;  set; }
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

  public virtual ICollection<Post>? Posts { get;  set; } 
  public virtual ICollection<Like>? Likes { get;  set; } 
  public virtual ICollection<Comment>? Comments { get;  set; }

  public User()
  {
    Posts = new List<Post>();
    Likes = new List<Like>();
    Comments = new List<Comment>();
  }

  public User(string username, string email, string passwordHash, DateOnly? birthDate):this()
  {
    Username = username;
    Email = email;
    PasswordHash = passwordHash;
    BirthDate = birthDate;
  }

  public void UpdateId(Guid id)
  {
    Id = id;
  }
  public void UpdateProfilePicture(string url)
  {
    ProfilePictureUrl = url;
  }

}
