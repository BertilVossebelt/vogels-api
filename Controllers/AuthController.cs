using Microsoft.AspNetCore.Mvc;
using vogels_api.Data;
using vogels_api.Dtos;
using vogels_api.Models.User;
using vogels_api.Services;
using vogels_api.Attributes;

namespace vogels_api.Controllers;

[Route("api/v1/auth")]
[ApiController]
public class AuthController : Controller
{
    private readonly AppDbContext _context;
    private readonly JwtService _jwtService;

    public AuthController(AppDbContext context, JwtService jwtService)
    {
        _context = context;
        _jwtService = jwtService;
    }

    [HttpPost("register")]
    public ActionResult<User> Register(RegisterDto dto)
    {
        var user = new User
        {
            Username = dto.Username,
            Email = dto.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            Honour = 100,
            Seeds = 1000,
            GoldenSeeds = 100,
            MaxTactics = 3,
        };

        _context.Users.Add(user);
        _context.SaveChanges();

        return Created("success", user);
    }

    [HttpPost("login")]
    public ActionResult<User> Login(LoginDto dto)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == dto.Email);
        
        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
        {
            return BadRequest(new { message = "Invalid credentials" });
        }

        var jwt = _jwtService.Generate(user.Id);

        var cookieOptions = new CookieOptions
        {
            Secure = true,
            HttpOnly = true,
            SameSite = SameSiteMode.None
        };

        Response.Cookies.Append("jwt", jwt, cookieOptions);

        return Ok(user);
    }
    
    [HttpPost("logout")]
    [Authorize]
    public IActionResult Logout()
    {
        Response.Cookies.Delete("jwt");
        return Ok(new { status = 200, message = "success" });
    }
}