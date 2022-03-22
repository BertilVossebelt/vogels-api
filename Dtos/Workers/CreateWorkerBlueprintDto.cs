namespace vogels_api.Dtos.Workers;

public class CreateWorkerBlueprintDto
{
    public uint BlueprintId { get; set; }
    public string Name { get; set; }
    public string? Image { get; set; }
    public string? Description { get; set; }
    public bool Premium { get; set; }
}