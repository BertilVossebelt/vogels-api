using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vogels_api.Models.Minister;

public class MinisterBlueprint    
{
    [Key]
    public uint Id { get; set; }
    
    [ForeignKey("MinistryId")]
    public Ministry Ministry { get; set; }
    public byte MinistryId { get; set; }

    public string? Image { get; set; }
    
    public string Trait { get; set; }
    
    public byte BaseActions { get; set; }
    
    public string? Description { get; set; }
    
    public bool Premium { get; set; }
}