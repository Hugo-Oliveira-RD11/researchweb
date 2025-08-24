using Microsoft.EntityFrameworkCore;
using reasearchweb.Infra.Data.Entities;

namespace reasearchweb.Infra.Data;

public class ApplicationDbContext : DbContext
{
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
  {
  }

  public DbSet<UserEntity> Users { get; set; }
}
