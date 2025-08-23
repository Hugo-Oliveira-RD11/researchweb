using Microsoft.EntityFrameworkCore;
using reasearchweb.Domain.Entities;

namespace reasearchweb.Infrastructure.Data;

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

            // Relacionamentos (apenas os necessários para Fase 1)
            // Os outros relacionamentos serão adicionados nas fases seguintes
        });

        // NOTA: As outras entidades (Connection, Post, Comment, Group, etc.)
        // serão configuradas nas fases 2 e 3 quando forem implementadas
    }
}
