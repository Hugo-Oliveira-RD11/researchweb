using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using reasearchweb.Application.Interfaces;
using reasearchweb.Application.Services;
using reasearchweb.Infra.Data;
using reasearchweb.Infra.Repositories;
using reasearchweb.Infra.Services;

namespace researchweb.Infra.DependecyInjection;

public static class PostgreSQL
{
  public static IServiceCollection AddInfraPostgreSQL(this IServiceCollection services,
                                                      string connectionString, string jwtSecret, int jwtExpirationInMinutes)
  {
    services.AddDbContext<ApplicationDbContext>(options =>
                                                options.UseNpgsql(connectionString));

    services.AddScoped<IUserRepository, UserRepository>();

    services.AddScoped<IAuthService>(provider =>
                                     new AuthService(jwtSecret, jwtExpirationInMinutes));

    return services;
  }
}
