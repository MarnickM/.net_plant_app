using plantdration.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plantdration.Models
{
    public class UserPlantDataService
    {
        public async Task<IEnumerable<UserPlant>> GetByUserId(int userId)
        {
            return await ApiService<IEnumerable<UserPlant>>.GetAsync($"UserPlants/{userId}");
        }
    }
}
