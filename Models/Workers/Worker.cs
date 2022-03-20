using System.ComponentModel.DataAnnotations.Schema;
using vogels_api.Models.Users;

namespace vogels_api.Models.Workers;

public class Worker      
{
    public ulong Id { get; set; }
    
    [ForeignKey("BlueprintId")]
    public WorkerBlueprint WorkerBlueprint { get; set; }
    public uint BlueprintId { get; set; }
    
    [ForeignKey("UserId")]
    public User User { get; set; }
    public ulong UserId { get; set; }
    
    public string CustomName { get; set; }
    
    public byte Happiness { get; set; }
    
    public uint? Xp { get; set; }
}