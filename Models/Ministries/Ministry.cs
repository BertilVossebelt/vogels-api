using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vogels_api.Models.Ministries;

public class Ministry      
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public byte Id { get; set; }
    
    public string Type { get; set; }
    
    [ForeignKey("Dislikes")]
    public Ministry Self { get; set; }
    public byte? Dislikes { get; set; }
}