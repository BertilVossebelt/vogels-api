using System.ComponentModel.DataAnnotations.Schema;

namespace vogels_api.Models.Law;

public class Law       
{
    public ulong Id { get; set; }

    [ForeignKey("BlueprintId")]
    public LawBlueprint LawBlueprint { get; set; }
    public uint BlueprintId { get; set; }

    [ForeignKey("UserId")]
    public User.User User { get; set; }
    public ulong UserId { get; set; }
}