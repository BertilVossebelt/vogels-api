using Microsoft.AspNetCore.Mvc;
using vogels_api.Data;
using vogels_api.Dtos.Minister;
using vogels_api.Models.Minister;

namespace vogels_api.Controllers.Minister;

[Route("api/ministry")]
[ApiController]
public class MinistryController : Controller {
    private readonly AppDbContext _context;

    public MinistryController(AppDbContext context) {
        _context = context;
    }

    [HttpPost]
    public IActionResult CreateMinistry(CreateMinistryDto dto) {
        var ministry = new Ministry {
            Type = dto.Type,
            Dislikes = dto.Dislikes,
        };

        _context.Ministry.Add(ministry);
        _context.SaveChanges();

        return Created("success", ministry);
    }
}