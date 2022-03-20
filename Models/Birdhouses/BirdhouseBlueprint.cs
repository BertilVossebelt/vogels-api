using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using vogels_api.Models.Ministries;

namespace vogels_api.Models.Birdhouses;

public class BirdhouseBlueprint       
{
    [Key]
    public uint Id { get; set; }
    
    [ForeignKey("MinistryId")]
    public Ministry Ministry { get; set; }
    public byte MinistryId { get; set; }
    
    public string? Image { get; set; }
    
    public byte BasePlots { get; set; }
    
    public string? Description { get; set; }
}