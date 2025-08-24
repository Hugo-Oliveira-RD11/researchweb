using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace reasearchweb.Infra.Data.Entities;

[Table("User")]
public class UserEntity
{
    [Key]
    public Guid Id { get; set; }

    [Required, MaxLength(50)]
    public string Username { get; set; }

    [Required, MaxLength(100), EmailAddress]
    public string Email { get; set; }

    [Required]
    public string PasswordHash { get; set; }

    [Required]
    public DateOnly BirthDate { get; set; }

    [MaxLength(500), Url]
    public string? ProfilePictureUrl { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    public UserEntity()
    {
        CreatedAt = DateTime.UtcNow;
        Id = Guid.NewGuid();
    }
}
