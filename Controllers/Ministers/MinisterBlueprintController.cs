using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using vogels_api.Data;
using vogels_api.Dtos.Ministers;
using vogels_api.Models.Ministers;
using vogels_api.Attributes;

namespace vogels_api.Controllers.Ministers;

[Route("api/v1/ministerBlueprints")]
[ApiController]
[Authorize]
public class MinisterBlueprintController : Controller
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public MinisterBlueprintController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<MinisterBlueprint> GetMinisterBlueprints()
    {
        var result = _context.Ministers.ToList();

        if (!result.Any()) return NotFound();
        return Ok(result);
    }
    
    [HttpGet("{id:int:min(1)}")]
    public ActionResult<MinisterBlueprint> GetMinisterBlueprintById(int id)
    {
        var result = _context.LawBlueprints.Where(m => m.Id == id);

        if (!result.Any()) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public ActionResult<MinisterBlueprint> CreateMinisterBlueprint(CreateMinisterBlueprintDto dto)
    {
        MinisterBlueprint ministerBlueprint = _mapper.Map<MinisterBlueprint>(dto);

        _context.MinisterBlueprints.Add(ministerBlueprint);
        _context.SaveChanges();

        return Ok(ministerBlueprint);
    }
    
    /*
    * Delete a minister blueprint.
    */
    [HttpDelete("{id:int:min(1)}")]
    public ActionResult<MinisterBlueprint> RemoveMinisterBlueprint(uint id)
    {
        var ministerBlueprint = new MinisterBlueprint { Id = id };
        
        _context.MinisterBlueprints.Attach(ministerBlueprint);
        _context.MinisterBlueprints.Remove(ministerBlueprint);
        _context.SaveChanges();

        return Ok(ministerBlueprint);
    }
}