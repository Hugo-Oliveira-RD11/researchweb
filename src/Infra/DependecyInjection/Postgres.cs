using Application.Services;
using Domain.Interfaces;
using Infra.Data;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using researchweb.Infra.Services;

// using researchweb.Infra.Repositories;
// using researchweb.Infra.Services;

namespace Infra.DependecyInjection;

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
