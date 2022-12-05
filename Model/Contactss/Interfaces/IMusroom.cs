namespace Model.Contactss.Interfaces;

public interface IMusroomFarm
{
    Task<MushroomFarm> PostMushroomAsync(MushroomFarm mushroom);
    Task<MushroomFarm> GetPlantMushroomAsync(string mui);
    Task<MushroomFarm> DeleteMushroomAsync(string mui);
}