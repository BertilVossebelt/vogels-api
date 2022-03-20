using System.ComponentModel.DataAnnotations.Schema;
using vogels_api.Models.Users;

namespace vogels_api.Models.Laws;

public class Law
{
    public ulong Id { get; set; }

    [ForeignKey("BlueprintId")]
    public LawBlueprint LawBlueprint { get; set; }
    public uint BlueprintId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }
    public ulong UserId { get; set; }
}