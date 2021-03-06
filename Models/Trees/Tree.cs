using System.ComponentModel.DataAnnotations.Schema;
using vogels_api.Models.Users;

namespace vogels_api.Models.Trees;

public class Tree      
{
    public ulong Id { get; set; }
    
    [ForeignKey("BlueprintId")]
    public TreeBlueprint TreeBlueprint { get; set; }
    public uint BlueprintId { get; set; }
    
    [ForeignKey("UserId")]
    public User User { get; set; }
    public ulong UserId { get; set; }
    
    public string Level { get; set; }
}