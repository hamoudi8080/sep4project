using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Model;

public class MushroomFarm
{
    [Key]
    [StringLength(50)]
    public string Mui { get; set; }
    
    [StringLength(50)]
    public string Name { get; set; }
    
    [JsonIgnore]
    public ICollection<Measurement> Measurements { get; set; }
}