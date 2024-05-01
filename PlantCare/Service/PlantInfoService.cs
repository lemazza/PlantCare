using Microsoft.EntityFrameworkCore;
using PlantCare;

namespace PlantCare.Service
{
    public class PlantInfoService : IPlantInfoService
    {
        public readonly PlantCareDBContext _plantCareDBContext;
        public PlantInfoService(PlantCareDBContext plantCareDBContext)
        {
            _plantCareDBContext = plantCareDBContext;

        }



        public async Task Add(PlantInfo plantInfo)
        {
            _plantCareDBContext.Add(plantInfo);
            _plantCareDBContext.SaveChanges();
        }

        public async Task<PlantInfo> Get(int id)
        {
            return await _plantCareDBContext.PlantInfo.SingleAsync(pl => pl.Id == id);
        }
    }
}
