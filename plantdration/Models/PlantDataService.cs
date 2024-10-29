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
        public async static Task<Plant> GetPlantByTag(string tag)
        {
            return await ApiService<Plant>.GetAsync($"plants/name/{tag}");
        }

        public async static Task<Plant> GetPlantById(int id)
        {
            return await ApiService<Plant>.GetAsync($"plants/{id}");
        }
    }
}