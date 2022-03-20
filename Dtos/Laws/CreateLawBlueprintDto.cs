namespace vogels_api.Dtos.Laws;

public class CreateLawBlueprintDto 
{
    public byte MinistryId { get; set; }
    public string Name { get; set; }
    public string? Image { get; set; }
    public string Requirement { get; set; }
    public string Benefit { get; set; }
}