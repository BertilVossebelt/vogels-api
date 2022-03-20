using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace vogels_api.Models.Tree;

public class TreeBlueprint      
{
    [Key]
    public uint Id { get; set; }
    
    public string Name { get; set; }
    
    public string? Image { get; set; }
    
    public byte BasePlots { get; set; }
    
    public string? Description { get; set; }
}