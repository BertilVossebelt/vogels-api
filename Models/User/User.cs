using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace vogels_api.Models.User;

public class User
{
    [Key]
    public ulong Id { get; set; }
 
    public ulong? AllianceId { get; set; }
    
    public string Username { get; set; }
    
    public string Email { get; set; }
    
    [JsonIgnore]
    public string Password { get; set; } 
    
    public sbyte Honour { get; set; }
    
    public ulong? Ranking { get; set; }
    
    public ulong Seeds { get; set; }
    
    public ulong GoldenSeeds { get; set; }
    
    public byte MaxTactics { get; set; }
}