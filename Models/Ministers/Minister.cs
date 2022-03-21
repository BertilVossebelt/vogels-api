using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using vogels_api.Models.Users;

namespace vogels_api.Models.Ministers;

public class Minister  
{
    [Key]
    public ulong Id { get; set; }
    
    [ForeignKey("BlueprintId")]
    public MinisterBlueprint MinisterBlueprint { get; set; }
    public uint BlueprintId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }
    public ulong UserId { get; set; }

    public string? CustomName { get; set; }
    
    public byte Happiness { get; set; }
    
    public byte Actions { get; set; }
    
    public uint? Xp { get; set; }
}