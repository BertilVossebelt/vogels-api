using System.Text.Json.Serialization;

namespace vogels_api.Models;

public class User
{
    public int Id { get; set; }
    public int? AllianceId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    [JsonIgnore]public string Password { get; set; }
    public byte Honour { get; set; }
    public int? Ranking { get; set; }
    public int? Seeds { get; set; }
    public int? GoldenSeeds { get; set; }
    public byte MaxTactics { get; set; }
}