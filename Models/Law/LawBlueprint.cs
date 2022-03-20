using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using vogels_api.Models.Minister;

namespace vogels_api.Models.Law;

public class LawBlueprint
{
    [Key]
    public uint Id { get; set; }
    
    [ForeignKey("MinistryId")]
    public Ministry Ministry { get; set; }
    public byte MinistryId { get; set; }
    
    public string Name { get; set; }
    
    public string? Image { get; set; }
    
    public string Requirement { get; set; }
    
    public string Benefit { get; set; }
}