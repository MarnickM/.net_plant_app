﻿using plantdration.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plantdration.Models
{
    public class UserPlantDataService
    {
        public async static Task<IEnumerable<UserPlant>> GetByUserId(int userId)
        {
            return await ApiService<IEnumerable<UserPlant>>.GetAsync($"UserPlants/{userId}");
        }

        public async static Task CreateUserPlant(UserPlant userPlant)
        {
            await ApiService<UserPlant>.PostAsync("UserPlants", userPlant);
        }

        public async static Task UpdateUserPlant(UserPlant userPlant)
        {
            string endPoint = $"UserPlants/{userPlant.UserId}/{userPlant.PlantId}";
            await ApiService<UserPlant>.PutAsync(endPoint, userPlant);
        }

        public async static Task DeleteUserPlant(UserPlant userPlant)
        {
            string endPoint = $"UserPlants/{userPlant.UserId}/{userPlant.PlantId}";
            await ApiService<UserPlant>.DeleteAsync(endPoint);
        }
    }
}
