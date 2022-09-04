using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticateController : ControllerBase
{
    private ApplicationContext _context;

    public AuthenticateController(ApplicationContext context)
    {
        _context = context; 
    }

    [HttpPost]
    [Route("register")]
    public async Task<ActionResult> RegisterUser(User user)
    {
        if (_context.Users.Any(u => u.Email == user.Email))
        {
            return Conflict();
        }

        var passwordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
        user.PasswordHash = passwordHash;

        user.ScheduledTasks = new List<ScheduledTask>();

        _context.Users.Add(user);

        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpPost]
    [Route("login")]
    public ActionResult LoginUser(User user)
    {
        if (!_context.Users.Any(u => u.Email == user.Email))
        {
            return Unauthorized();
        }

        var dbUser = _context.Users.Where(u => u.Email == user.Email).First();

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, dbUser.Email),
            new Claim(ClaimTypes.NameIdentifier, dbUser.UserId.ToString())
        };

        var jwt = new JwtSecurityToken(
            claims: claims,
            audience: AuthOptions.Audience,
            issuer: AuthOptions.Issuer,
            expires: DateTime.Now.Add(TimeSpan.FromMinutes(30)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                SecurityAlgorithms.HmacSha256));

        var tokenString = new JwtSecurityTokenHandler().WriteToken(jwt);

        return Ok(tokenString);
    }
}