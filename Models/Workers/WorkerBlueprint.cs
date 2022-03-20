using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace vogels_api.Models.Workers;

public class WorkerBlueprint      
{
    [Key]
    public uint Id { get; set; }
    
    public string Name { get; set; }
    
    public string? Image { get; set; }
    
    public byte? Description { get; set; }
    
    public bool Premium { get; set; }
}