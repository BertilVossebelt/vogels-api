using Microsoft.AspNetCore.Mvc;
using vogels_api.Data;
using vogels_api.Dtos.Laws;
using vogels_api.Models.Laws;
using vogels_api.Attributes;

namespace vogels_api.Controllers.Laws;

[Route("api/v1/lawBlueprints")]
[ApiController]
[Authorize]
public class LawBlueprintController : Controller
{
    private readonly AppDbContext _context;

    public LawBlueprintController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<LawBlueprint> GetLawBlueprints()
    {
        var result = _context.LawBlueprints.ToList();

        if (!result.Any()) return NotFound();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public ActionResult<LawBlueprint> GetLawBlueprintById(int id)
    {
        var result = _context.LawBlueprints.Where(l => l.Id == id);

        if (!result.Any()) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public ActionResult<LawBlueprint> CreateLawBlueprint(CreateLawBlueprintDto dto)
    {
        var lawBlueprint = new LawBlueprint
        {
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