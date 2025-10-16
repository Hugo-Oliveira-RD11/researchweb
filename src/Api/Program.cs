using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Application.UseCases;
using Infra.Data;
using Infra.DependecyInjection;
using Infra.Data;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var jwtSecret = builder.Configuration["Jwt:Secret"];
var jwtExpiration = builder.Configuration.GetValue<int>("Jwt:ExpirationInMinutes");

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddInfraPostgreSQL(connectionString, jwtSecret, jwtExpiration);

builder.Services.AddScoped<UserUseCases>();

var key = Encoding.ASCII.GetBytes(jwtSecret);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
  .AddJwtBearer(options =>
  {
    options.TokenValidationParameters = new TokenValidationParameters
    {
      ValidateIssuerSigningKey = true,
      IssuerSigningKey = new SymmetricSecurityKey(key),
      ValidateIssuer = false,
      ValidateAudience = false
    };
  });


var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.EnvironmentName == "Docker")
{
  app.MapOpenApi();
  app.MapScalarApiReference("/docs");
  using var scope = app.Services.CreateScope();
  var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
  dbContext.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
