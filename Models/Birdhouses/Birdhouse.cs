using System.ComponentModel.DataAnnotations.Schema;
using vogels_api.Models.Users;

namespace vogels_api.Models.Birdhouses;

public class Birdhouse       
{
    public ulong Id { get; set; }

    [ForeignKey("BlueprintId")]
    public BirdhouseBlueprint BirdhouseBlueprint { get; set; }
    public uint BlueprintId;

    [ForeignKey("UserId")]
    public User User { get; set; }
    public ulong UserId { get; set; }
    
    public byte Level { get; set; }
}