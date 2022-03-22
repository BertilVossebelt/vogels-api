using Microsoft.AspNetCore.Mvc;
using vogels_api.Data;
using vogels_api.Dtos.Ministers;
using vogels_api.Models.Ministers;
using vogels_api.Attributes;

namespace vogels_api.Controllers.Ministers;

[Route("api/v1/ministers")]
[ApiController]
[Authorize]
public class MinisterController : Controller
{
    private readonly AppDbContext _context;

    public MinisterController(AppDbContext context)
    {
        _context = context;
    }

    /*
     * Gets all ministers of the authenticated user.
    */
    [HttpGet]
    public ActionResult<Minister> GetMinisters()
    {
        var userId = Request.HttpContext.Items["UserId"];
        var result = _context.Ministers
            .Where(minister => minister.UserId == (ulong)userId);

        if (!result.Any()) return NotFound();
        return Ok(result);
    }

    /*
     * Gets ministers by id of the authenticated user.
     */
    [HttpGet("{id:long:min(1)}")]
    public ActionResult<Minister> GetMinisterById(ulong id)
    {
        var userId = Request.HttpContext.Items["UserId"];
        var result = _context.Ministers
            .Where(minister => minister.UserId == (ulong)userId)
            .Where(minister => minister.Id == id);

        if (!result.Any()) return NotFound();
        return Ok(result);
    }

    /*
     * Create a new minister for the authenticated user,
     * based on a minister blueprint.
     */
    [HttpPost]
    public ActionResult<Minister> CreateMinister(CreateMinisterDto dto)
    {
        var userId = Request.HttpContext.Items["UserId"];
        byte actions = _context.MinisterBlueprints
            .Where(m => m.Id == dto.BlueprintId)
            .ToArray()[0].BaseActions;

        var minister = new Minister
        {
            BlueprintId = dto.BlueprintId,
            UserId = (ulong)userId,
            CustomName = dto.CustomName,
            Happiness = 100,
            Actions = actions,
        };

        _context.Ministers.Add(minister);
        _context.SaveChanges();

        return Ok(minister);
    }

    /*
     * Delete a minister of the authenticated user by id.
     */
    [HttpDelete("{id:long:min(1)}")]
    public ActionResult<Minister> RemoveMinister(ulong id)
    {
        var userId = Request.HttpContext.Items["UserId"];
        var minister = _context.Ministers
            .Where(minister => minister.UserId == (ulong)userId)
            .FirstOrDefault(minister => minister.Id == id);

        if (minister is null) return NotFound();
        
        _context.Ministers.Remove(minister);
        _context.SaveChanges();

        return Ok(minister);
    }
}