using AutoMapper;
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
    private readonly IMapper _mapper;

    public LawBlueprintController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /*
     * Get all law blueprints
     */
    [HttpGet]
    public ActionResult<LawBlueprint> GetLawBlueprints()
    {
        var result = _context.LawBlueprints.ToList();

        if (!result.Any()) return NotFound();
        return Ok(result);
    }

    /*
     * Get law blueprint by id.
     */
    [HttpGet("{id:int:min(1)}")]
    public ActionResult<LawBlueprint> GetLawBlueprintById(int id)
    {
        var result = _context.LawBlueprints.Where(l => l.Id == id);

        if (!result.Any()) return NotFound();
        return Ok(result);
    }

    /*
     * Create a new law blueprint.
     */
    [HttpPost]
    public ActionResult<LawBlueprint> CreateLawBlueprint(CreateLawBlueprintDto dto)
    {
        LawBlueprint lawBlueprint = _mapper.Map<LawBlueprint>(dto);
        
        _context.LawBlueprints.Add(lawBlueprint);
        _context.SaveChanges();

        return Created("success", lawBlueprint);
    }
    
    /*
    * Delete a law blueprint.
    */
    [HttpDelete("{id:int:min(1)}")]
    public ActionResult<LawBlueprint> RemoveLawBlueprint(uint id)
    {
        var lawBlueprint = new LawBlueprint { Id = id };
        
        _context.LawBlueprints.Attach(lawBlueprint);
        _context.LawBlueprints.Remove(lawBlueprint);
        _context.SaveChanges();

        return Ok(lawBlueprint);
    }

}