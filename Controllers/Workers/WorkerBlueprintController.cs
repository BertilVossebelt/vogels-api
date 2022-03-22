using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using vogels_api.Data;
using vogels_api.Dtos.Workers;
using vogels_api.Models.Workers;
using vogels_api.Attributes;

namespace vogels_api.Controllers.Workers;

[Route("api/v1/workerBlueprints")]
[ApiController]
[Authorize]
public class WorkerBlueprintController : Controller
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public WorkerBlueprintController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /*
    * Get all worker blueprints.
    */
    [HttpGet]
    public ActionResult<WorkerBlueprint> GetWorkerBlueprints()
    {
        var result = _context.WorkerBlueprints.ToList();

        if (!result.Any()) return NotFound();
        return Ok(result);
    }
    
    /*
    * Get worker blueprint by id.
    */
    [HttpGet("{id:int:min(1)}")]
    public ActionResult<WorkerBlueprint> GetWorkerBlueprintById(int id)
    {
        var result = _context.LawBlueprints.Where(m => m.Id == id);

        if (!result.Any()) return NotFound();
        return Ok(result);
    }

    /*
    * Create a new worker blueprint.
    */
    [HttpPost]
    public ActionResult<WorkerBlueprint> CreateWorkerBlueprint(CreateWorkerBlueprintDto dto)
    {
        WorkerBlueprint workerBlueprint = _mapper.Map<WorkerBlueprint>(dto);

        _context.WorkerBlueprints.Add(workerBlueprint);
        _context.SaveChanges();

        return Ok(workerBlueprint);
    }
    
    /*
    * Delete a worker blueprint by id.
    */
    [HttpDelete("{id:int:min(1)}")]
    public ActionResult<WorkerBlueprint> RemoveWorkerBlueprint(uint id)
    {
        var workerBlueprint = new WorkerBlueprint { Id = id };
        
        _context.WorkerBlueprints.Attach(workerBlueprint);
        _context.WorkerBlueprints.Remove(workerBlueprint);
        _context.SaveChanges();

        return Ok(workerBlueprint);
    }
}