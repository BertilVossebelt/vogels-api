using Microsoft.AspNetCore.Mvc;
using vogels_api.Data;
using vogels_api.Dtos.Laws;
using vogels_api.Attributes;
using vogels_api.Models.Laws;

namespace vogels_api.Controllers.Laws;

[Route("api/v1/laws")]
[ApiController]
[Authorize]
public class LawController : Controller
{
    private readonly AppDbContext _context;

    public LawController(AppDbContext context)
    {
        _context = context;
    }

    /*
    * Gets all laws of the authenticated user.
    */
    [HttpGet]
    public ActionResult<Law> GetLaws()
    {
        var userId = Request.HttpContext.Items["UserId"];
        var result = _context.Laws
            .Where(law => law.UserId == (ulong)userId);

        if (!result.Any()) return NotFound();
        return Ok(result);
    }

    /*
     * Gets laws by id of the authenticated user.
     */
    [HttpGet("{id:long:min(1)}")]
    public ActionResult<Law> GetLawsById(ulong id)
    {
        var userId = Request.HttpContext.Items["UserId"];
        var result = _context.Laws
            .Where(law => law.UserId == (ulong)userId)
            .Where(law => law.Id == id);

        if (!result.Any()) return NotFound();
        return Ok(result);
    }

    /*
    * Create a new law for the authenticated user,
    * based on a law blueprint.
    */
    [HttpPost]
    public ActionResult<Law> CreateLaw(CreateLawDto dto)
    {
        var userId = Request.HttpContext.Items["UserId"];
        var law = new Law
        {
            BlueprintId = dto.BlueprintId,
            UserId = (ulong)userId,
        };

        _context.Laws.Add(law);
        _context.SaveChanges();

        return Created("success", law);
    }

    /*
    * Delete a law of the authenticated user by id.
    */
    [HttpDelete("{id:long:min(1)}")]
    public ActionResult<Law> RemoveLaw(ulong id)
    {
        var userId = Request.HttpContext.Items["UserId"];
        var law = _context.Laws
            .Where(law => law.UserId == (ulong)userId)
            .FirstOrDefault(law => law.Id == id);

        if (law is null) return NotFound();

        _context.Laws.Remove(law);
        _context.SaveChanges();

        return Ok(law);
    }
}