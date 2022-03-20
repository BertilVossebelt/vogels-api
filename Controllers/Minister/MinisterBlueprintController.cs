using Microsoft.AspNetCore.Mvc;
using vogels_api.Data;
using vogels_api.Dtos.Minister;
using vogels_api.Models.Minister;
using vogels_api.Attributes;

namespace vogels_api.Controllers.Minister;

[Route("api/v1/minister")]
[ApiController]
[Authorize]
public class MinisterBlueprintController : Controller
{
    private readonly AppDbContext _context;

    public MinisterBlueprintController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<MinisterBlueprint> GetMinisterBlueprints()
    {
        var result = _context.Ministers.ToList();

        if (!result.Any()) return NotFound();
        return Ok(result);
    }
    
    [HttpGet("{id:int}")]
    public ActionResult<MinisterBlueprint> GetMinisterBlueprintById(int id)
    {
        var result = _context.LawBlueprints.Where(m => m.Id == id);

        if (!result.Any()) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public ActionResult<MinisterBlueprint> CreateMinisterBlueprint(CreateMinisterBLueprintDto dto)
    {
        var ministerBlueprint = new MinisterBlueprint
        {
            MinistryId = dto.MinistryId,
            Image = dto.Image,
            Trait = dto.Trait,
            BaseActions = dto.BaseActions,
            Description = dto.Description,
            Premium = dto.Premium,
        };

        _context.MinisterBlueprints.Add(ministerBlueprint);
        _context.SaveChanges();

        return Ok(ministerBlueprint);
    }
}