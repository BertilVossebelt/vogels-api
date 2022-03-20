using Microsoft.AspNetCore.Mvc;
using vogels_api.Data;
using vogels_api.Dtos.Minister;
using vogels_api.Models.Minister;
using vogels_api.Attributes;

namespace vogels_api.Controllers.Minister;

[Route("api/v1/ministry")]
[ApiController]
[Authorize]
public class MinistryController : Controller
{
    private readonly AppDbContext _context;

    public MinistryController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<Ministry> GetMinistry()
    {
        var result = _context.Ministry.ToList();

        if (!result.Any()) return NotFound();
        return Ok(result);
    }
    
    [HttpGet("{id:int}")]
    public ActionResult<Ministry> GetMinistryById(int id)
    {
        var result = _context.Ministry.Where(m => m.Id == id);

        if (!result.Any()) return NotFound();
        return Ok(result);
    }
    
    [HttpPost]
    public ActionResult<Ministry> CreateMinistry(CreateMinistryDto dto)
    {
        var ministry = new Ministry
        {
            Type = dto.Type,
            Dislikes = dto.Dislikes,
        };

        _context.Ministry.Add(ministry);
        _context.SaveChanges();

        return Created("success", ministry);
    }
}