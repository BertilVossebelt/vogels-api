namespace vogels_api.Dtos.Ministers;

public class CreateMinisterDto
{
    public uint BlueprintId { get; set; }
    public ulong UserId { get; set; }
    public string? CustomName { get; set; }
}