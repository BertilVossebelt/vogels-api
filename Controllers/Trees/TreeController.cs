using Microsoft.AspNetCore.Mvc;
using vogels_api.Data;
using vogels_api.Dtos.Trees;
using vogels_api.Models.Trees;
using vogels_api.Attributes;

namespace vogels_api.Controllers.Trees;

[Route("api/v1/trees")]
[ApiController]
[Authorize]
public class TreeController : Controller
{
    private readonly AppDbContext _context;

    public TreeController(AppDbContext context)
    {
        _context = context;
    }

    /*
     * Gets all trees of the authenticated user.
    */
    [HttpGet]
    public ActionResult<Tree> GetTrees()
    {
        var result = _context.Trees.ToList();

        if (!result.Any()) return NotFound();
        return Ok(result);
    }

    /*
     * Gets tree by id of the authenticated user.
     */
    [HttpGet("{id:long:min(1)}")]
    public ActionResult<Tree> GetTreeById(ulong id)
    {
        var userId = Request.HttpContext.Items["UserId"];
        var result = _context.Trees
            .Where(tree => tree.UserId == (ulong)userId)
            .Where(tree => tree.Id == id);

        if (!result.Any()) return NotFound();
        return Ok(result);
    }

    /*
     * Create a new tree for the authenticated user,
     * based on a tree blueprint.
     */
    [HttpPost]
    public ActionResult<Tree> CreateTree(CreateTreeDto dto)
    {
        var userId = Request.HttpContext.Items["UserId"];
        byte actions = _context.TreeBlueprints
            .Where(treeBlueprint => treeBlueprint.Id == dto.BlueprintId)
            .ToArray()[0].BasePlots;

        var tree = new Tree
        {
            BlueprintId = dto.BlueprintId,
        };

        _context.Trees.Add(tree);
        _context.SaveChanges();

        return Ok(tree);
    }

    /*
     * Delete a tree of the authenticated user by id.
     */
    [HttpDelete("{id:long:min(1)}")]
    public ActionResult<Tree> RemoveTree(ulong id)
    {
        var userId = Request.HttpContext.Items["UserId"];
        var tree = _context.Trees
            .Where(tree => tree.UserId == (ulong)userId)
            .FirstOrDefault(tree => tree.Id == id);

        if (tree is null) return NotFound();
        
        _context.Trees.Remove(tree);
        _context.SaveChanges();

        return Ok(tree);
    }
}