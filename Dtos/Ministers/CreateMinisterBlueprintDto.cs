namespace vogels_api.Dtos.Ministers;

public class CreateMinisterBlueprintDto
{
    public byte MinistryId { get; set; }
    public string? Image { get; set; }
    public string Trait { get; set; }
    public byte BaseActions { get; set; }
    public string? Description { get; set; }
    public bool Premium { get; set; }
}