using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vogels_api.Models.Minister;

public class Minister  
{
    [Key]
    public ulong Id { get; set; }
    
    [ForeignKey("MinisterId")]
    public MinisterBlueprint MinisterBlueprint { get; set; }
    public uint MinisterId { get; set; }

    public string? CustomName { get; set; }
    
    public byte Happiness { get; set; }
    
    public byte Actions { get; set; }
    
    public uint? Xp { get; set; }
}