using plantdration.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plantdration.Models
{
    public class PlantDataService
    {
        public async static Task<List<Plant>> GetPlansAsync()
        {
            return await ApiService<List<Plant>>.GetAsync("plants");
        }
                public async static Task InsertPlantAsync(Plant plant)
        {
            await ApiService<Plant>.PostAsync("plants", plant);
        }

        public async static Task UpdatePlantAsync(Plant plant)
        {
            await ApiService<Plant>.PutAsync($"plants/{plant.Id}", plant);
        }

        public async static Task DeletePlantAsync(Plant plant)
        {
            await ApiService<Plant>.DeleteAsync($"plants/{plant.Id}");
        }
    }
}
