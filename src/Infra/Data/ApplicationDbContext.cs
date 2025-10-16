using Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data;

public class ApplicationDbContext : DbContext
{
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
  {
  }

  public DbSet<UserEntity> Users { get; set; }
}
