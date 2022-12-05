namespace Model.Contactss.Interfaces;

public interface IMeasurement
{
    //hello hamoudi
    Task<Measurement> AddMeasurementAsync(Measurement measurement);
    Task<Measurement> GetMeasurementAsync(string mui);
    Task<ICollection<Measurement>> GetMeasurementHistoryAsync(string eui);
 
}