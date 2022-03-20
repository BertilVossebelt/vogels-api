using System.ComponentModel.DataAnnotations.Schema;
using vogels_api.Models.User;

namespace vogels_api.Models.Tree;

public class Tree      
{
    public ulong Id { get; set; }
    
    [ForeignKey("BlueprintId")]
    public TreeBlueprint TreeBlueprint { get; set; }
    public uint BlueprintId { get; set; }
    
    [ForeignKey("UserId")]
    public User.User User { get; set; }
    public ulong UserId { get; set; }
    
    public string Level { get; set; }
}