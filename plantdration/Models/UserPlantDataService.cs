using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plantdration.Models
{
    public class UserPlantDataService
    {
        // Set userPlants to static
        private static readonly List<UserPlant> userPlants = new List<UserPlant>
    {
        new UserPlant { Id = 1, UserId = 1, PlantId = 1, DateAssigned = DateTime.Now },
        new UserPlant { Id = 2, UserId = 1, PlantId = 2, DateAssigned = DateTime.Now },
        new UserPlant { Id = 3, UserId = 2, PlantId = 5, DateAssigned = DateTime.Now },
        new UserPlant { Id = 4, UserId = 2, PlantId = 6, DateAssigned = DateTime.Now },
        new UserPlant { Id = 5, UserId = 3, PlantId = 8, DateAssigned = DateTime.Now },
        new UserPlant { Id = 6, UserId = 3, PlantId = 9, DateAssigned = DateTime.Now },
    };

        // Static method can now access static userPlants
        public static IEnumerable<UserPlant> GetByUserId(int id)
        {
            return userPlants.Where(x => x.UserId == id);
        }

        public static void AddUserPlant(UserPlant userPlant)
        {
            // Assign a new ID by finding the maximum ID currently in the list and adding 1
            if (userPlants.Any())
            {
                userPlant.Id = userPlants.Max(up => up.Id) + 1;
            }
            else
            {
                userPlant.Id = 1; // Start with ID 1 if list is empty
            }

            // Set the current date/time when the plant is added
            userPlant.DateAssigned = DateTime.Now;

            // Add the new UserPlant to the static list
            userPlants.Add(userPlant);
        }
    }

}
