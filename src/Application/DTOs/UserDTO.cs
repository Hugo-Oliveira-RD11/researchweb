namespace reasearchweb.Application.DTOs;

public class UserDto
{
  public Guid Id { get; set; }
  public string Username { get; set; }
  public string Email { get; set; }
  public DateOnly BirthDate { get; set; }
  public string? ProfilePictureUrl { get; set; }
  public DateTime CreatedAt { get; set; }
}
