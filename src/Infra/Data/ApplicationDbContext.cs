using Microsoft.EntityFrameworkCore;
using reasearchweb.Domain.Entities;

namespace reasearchweb.Infra.Data;

public class ApplicationDbContext : DbContext
{
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
  {
  }

  public DbSet<User> Users { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<User>(entity =>
    {
      entity.HasKey(u => u.Id);

      entity.Property(u => u.Username)
        .IsRequired()
        .HasMaxLength(50);

      entity.Property(u => u.Email)
        .IsRequired()
        .HasMaxLength(100);

      entity.Property(u => u.PasswordHash)
        .IsRequired();

      entity.Property(u => u.BirthDate)
        .IsRequired();

      entity.Property(u => u.ProfilePictureUrl)
        .HasMaxLength(500);

      entity.Property(u => u.CreatedAt)
        .IsRequired();

      // Índices únicos
      entity.HasIndex(u => u.Email)
        .IsUnique();

      entity.HasIndex(u => u.Username)
        .IsUnique();
    });

  }
}
