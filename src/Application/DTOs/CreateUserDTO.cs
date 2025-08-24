using System.ComponentModel.DataAnnotations;

namespace reasearchweb.Application.DTOs;

public class CreateUserDto
{
  [Required, MinLength(3), MaxLength(50)]
  public string Username { get; set; }

  [Required, EmailAddress, MaxLength(100)]
  public string Email { get; set; }

  [Required, MinLength(6)]
  public string Password { get; set; }

  [Required]
  public DateTime BirthDate { get; set; }
}
