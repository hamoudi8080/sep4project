using System.ComponentModel.DataAnnotations;

namespace Model;

public class Measurement
{
    [Key]
    public int MeasurementId { get; set; }

    [Required]
    public DateTime Timestamp { get; set; }
    

    public ICollection<MeasurementType> MeasurementTypes { get; set; }
}
