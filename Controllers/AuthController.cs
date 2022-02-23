using vogels_api.Data;
using vogels_api.Dtos;
using Microsoft.AspNetCore.Mvc;
using vogels_api.Models.User;
using vogels_api.Services;

namespace vogels_api.Controllers;

[Route("api")]
[ApiController]
public class AuthController : Controller {
    private readonly AppDbContext _context;
    private readonly JwtService _jwtService;

    public AuthController(AppDbContext context, JwtService jwtService) {
        _context = context;
        _jwtService = jwtService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterDto dto) {
        var user = new User {
            Username = dto.Username,
            Email = dto.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            Honour = 100,
            Seeds = 1000,
            GoldenSeeds = 100,
            MaxTactics = 3,
        };

        _context.Users.Add(user);
        user.Id = _context.SaveChanges();

        return Created("success", user);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginDto dto) {
        var user = _context.Users.FirstOrDefault(u => u.Email == dto.Email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.Password)) {
            return BadRequest(new {message = "Invalid credentials"});
        }

        var jwt = _jwtService.Generate(user.Id);

        var cookieOptions = new CookieOptions {
            Secure = true,
            HttpOnly = true,
            SameSite = SameSiteMode.None
        };

        Response.Cookies.Append("jwt", jwt, cookieOptions);

        return Ok(new {status = 200, message = "success"});
    }

    [HttpGet("user")]
    public IActionResult User() {
        try {
            var jwt = Request.Cookies["jwt"];
            if (jwt == null) return Unauthorized();

            var token = _jwtService.Verify(jwt);
            int userId = int.Parse(token.Issuer);

            var user = _context.Users.FirstOrDefault(u => u.Id == userId);

            return Ok(user);
        }
        catch (Exception e) {
            return Unauthorized();
        }
    }

    [HttpPost("logout")]
    public IActionResult Logout() {
        Response.Cookies.Delete("jwt");
        return Ok(new {status = 200, message = "success"});
    }
}