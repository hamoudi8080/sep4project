namespace Model.Contactss.Interfaces;

public interface IMeasurementType
{
    Task <MeasurementType> AddMeasurementTypeAsync(MeasurementType measurementType);
    Task<IMeasurementType> GetMeasurementTypeAsync();
    
}