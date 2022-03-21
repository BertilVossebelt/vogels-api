using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using vogels_api.Data;
using vogels_api.Dtos.Trees;
using vogels_api.Models.Trees;
using vogels_api.Attributes;

namespace vogels_api.Controllers.Trees;

[Route("api/v1/treeBlueprints")]
[ApiController]
[Authorize]
public class TreeBlueprintController : Controller
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public TreeBlueprintController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /*
     * Get all tree blueprints
     */
    [HttpGet]
    public ActionResult<TreeBlueprint> GetTreeBlueprints()
    {
        var result = _context.TreeBlueprints.ToList();

        if (!result.Any()) return NotFound();
        return Ok(result);
    }

    /*
     * Get tree blueprint by id.
     */
    [HttpGet("{id:int:min(1)}")]
    public ActionResult<TreeBlueprint> GetTreeBlueprintById(int id)
    {
        var result = _context.LawBlueprints.Where(l => l.Id == id);

        if (!result.Any()) return NotFound();
        return Ok(result);
    }

    /*
     * Create a new tree blueprint.
     */
    [HttpPost]
    public ActionResult<TreeBlueprint> CreateTreeBlueprint(CreateTreeBlueprintDto dto)
    {
        TreeBlueprint treeBlueprint = _mapper.Map<TreeBlueprint>(dto);

        _context.TreeBlueprints.Add(treeBlueprint);
        _context.SaveChanges();

        return Created("success", treeBlueprint);
    }
    
    /*
    * Delete a tree blueprint.
    */
    [HttpDelete("{id:int:min(1)}")]
    public ActionResult<TreeBlueprint> RemoveTreeBlueprint(uint id)
    {
        var treeBlueprint = new TreeBlueprint { Id = id };
        
        _context.TreeBlueprints.Attach(treeBlueprint);
        _context.TreeBlueprints.Remove(treeBlueprint);
        _context.SaveChanges();

        return Ok(treeBlueprint);
    }
}