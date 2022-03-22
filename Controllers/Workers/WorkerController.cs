using Microsoft.AspNetCore.Mvc;
using vogels_api.Data;
using vogels_api.Dtos.Workers;
using vogels_api.Models.Workers;
using vogels_api.Attributes;

namespace vogels_api.Controllers.Workers;

[Route("api/v1/workers")]
[ApiController]
[Authorize]
public class WorkerController : Controller
{
    private readonly AppDbContext _context;

    public WorkerController(AppDbContext context)
    {
        _context = context;
    }

    /*
     * Get all workers of the authenticated user.
    */
    [HttpGet]
    public ActionResult<Worker> GetWorkers()
    {
        var userId = Request.HttpContext.Items["UserId"];
        var result = _context.Workers
            .Where(worker => worker.UserId == (ulong)userId);

        if (!result.Any()) return NotFound();
        return Ok(result);
    }

    /*
     * Get workers of the authenticated user by id.
     */
    [HttpGet("{id:long:min(1)}")]
    public ActionResult<Worker> GetWorkerById(ulong id)
    {
        var userId = Request.HttpContext.Items["UserId"];
        var result = _context.Workers
            .Where(worker => worker.UserId == (ulong)userId)
            .Where(worker => worker.Id == id);

        if (!result.Any()) return NotFound();
        return Ok(result);
    }

    /*
     * Create a new worker for the authenticated user,
     * based on a worker blueprint.
     */
    [HttpPost]
    public ActionResult<Worker> CreateWorker(CreateWorkerDto dto)
    {
        var userId = Request.HttpContext.Items["UserId"];
        var worker = new Worker
        {
            BlueprintId = dto.BlueprintId,
            UserId = (ulong)userId,
            CustomName = dto.CustomName,
            Happiness = 100,
        };

        _context.Workers.Add(worker);
        _context.SaveChanges();

        return Ok(worker);
    }

    /*
     * Delete a worker of the authenticated user by id.
     */
    [HttpDelete("{id:long:min(1)}")]
    public ActionResult<Worker> RemoveWorker(ulong id)
    {
        var userId = Request.HttpContext.Items["UserId"];
        var worker = _context.Workers
            .Where(worker => worker.UserId == (ulong)userId)
            .FirstOrDefault(worker => worker.Id == id);

        if (worker is null) return NotFound();
        
        _context.Workers.Remove(worker);
        _context.SaveChanges();

        return Ok(worker);
    }
}