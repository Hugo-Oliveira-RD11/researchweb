using Application.DTOs;
using Application.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace reasearchweb.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
  private readonly UserUseCases _userUseCases;

  public UsersController(UserUseCases userUseCases)
  {
    _userUseCases = userUseCases;
  }

[HttpPost("register")]
public async Task<IActionResult> Register([FromBody] CreateUserDto createUserDto)
{
  try
  {
    var user = await _userUseCases.CreateUserAsync(createUserDto);
    return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
  }
  catch (ArgumentException ex)
  {
    return BadRequest(new { message = ex.Message });
  }
}

[HttpPost("login")]
public async Task<IActionResult> Login([FromBody] LoginRequest request)
{
  try
  {
    var token = await _userUseCases.AuthenticateUserAsync(request.Email, request.Password);
    return Ok(new { Token = token });
  }
  catch (UnauthorizedAccessException)
  {
    return Unauthorized(new { message = "Invalid credentials" });
  }
}

[Authorize]
[HttpGet("{id}")]
public async Task<IActionResult> GetUser(Guid id)
{
  try
  {
    var user = await _userUseCases.GetUserByIdAsync(id);
    return Ok(user);
  }
  catch (KeyNotFoundException)
  {
    return NotFound();
  }
}

[Authorize]
[HttpPut("{id}/profile-picture")]
public async Task<IActionResult> UpdateProfilePicture(Guid id, [FromBody] UpdateProfilePictureRequest request)
{
  try
  {
    await _userUseCases.UpdateUserProfilePictureAsync(id, request.ProfilePictureUrl);
    return NoContent();
  }
  catch (KeyNotFoundException)
  {
    return NotFound();
  }
}
}

public class LoginRequest
{
  public string Email { get; set; }
  public string Password { get; set; }
}

public class UpdateProfilePictureRequest
{
  public string ProfilePictureUrl { get; set; }
}
