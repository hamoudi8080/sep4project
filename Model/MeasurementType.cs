using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Model
{
    
}

[Index(nameof(Timestamp))]

public class MeasurementType
{
    [Key]
    public int MeasurementTypeId { get; set; }
    
    [Required]
  
    public DateTime Timestamp { get; set; }

    [Required]
    public float Temperature { get; set; }

    [Range(0, 100)]
    [Required]
    public int Humidity { get; set; }

    [Required]
    public int Co2 { get; set; }
    
    
}