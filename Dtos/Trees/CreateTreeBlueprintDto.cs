namespace vogels_api.Dtos.Trees;

public class CreateTreeBlueprintDto
{
    public string Name { get; set; }
    public string? Image { get; set; }
    public byte BasePlots { get; set; }
    public string? Description { get; set; }
}