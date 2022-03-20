using vogels_api.Data;
using Microsoft.AspNetCore.Mvc;
using vogels_api.Dtos.Law;
using vogels_api.Models.Law;
namespace vogels_api.Controllers.Law;

[Route("api/lawblueprint")]
[ApiController]
public class LawBlueprintController : Controller {
    private readonly AppDbContext _context;

    public LawBlueprintController(AppDbContext context) {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetLawBlueprints() {
        var result = _context.LawBlueprints.ToList();
        
        if (!result.Any()) return NotFound();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetLawBlueprintById(int id) {
        var result = _context.LawBlueprints.Where(l => l.Id == id);

        if (!result.Any()) return NotFound();
        return Ok(result);
    }
    
    [HttpPost]
    public IActionResult CreateLawBlueprint(CreateLawBlueprintDto dto) {
        var lawBlueprint = new LawBlueprint {
            MinistryId = dto.MinistryId,
            Name = dto.Name,
            Image = dto.Image,
            Requirement = dto.Requirement,
            Benefit = dto.Benefit,
        };

        _context.LawBlueprints.Add(lawBlueprint);
        _context.SaveChanges();
        
        return Created("success", lawBlueprint);
    }
}