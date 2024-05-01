using PlantCare;

namespace PlantCare.Service
{
    public interface IPlantInfoService
    {
        Task Add(PlantInfo plantInfo);
        Task<PlantInfo> Get(int id);
    }
}