using Microsoft.AspNetCore.Mvc;
using vogels_api.Data;
using vogels_api.Dtos.Laws;
using vogels_api.Attributes;
using vogels_api.Models.Laws;

namespace vogels_api.Controllers.Laws;

[Route("api/v1/law")]
[ApiController]
[Authorize]
public class LawController : Controller
{
    private readonly AppDbContext _context;

    public LawController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public Object GetLaws()
    {
        var userId = Request.HttpContext.Items["UserId"];
        var result = _context.Laws.Where(l => l.UserId == (ulong)userId);

        if (!result.Any()) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public ActionResult<Law> CreateLaw(CreateLawDto dto)
    {
        var law = new Law
        {
            BlueprintId = dto.BlueprintId,
            UserId = dto.UserId,
        };

        _context.Laws.Add(law);
        _context.SaveChanges();

        return Created("success", law);
    }
    
    [HttpDelete("{id:long:min(1)}")]
    public ActionResult<Law> RemoveLaw(ulong id)
    {
        var law = new Law { Id = id };

        _context.Laws.Attach(law);
        _context.Laws.Remove(law);
        _context.SaveChanges();

        return Ok(law);
    }
}