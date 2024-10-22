using Microsoft.EntityFrameworkCore;
using plantdrationAPI.Models;

namespace plantdrationAPI
{
    public class DBInitializer
    {
        public static void Initialize(PlantContext context)
        {
            context.Database.EnsureCreated();

            // Check if any users exist, meaning the DB has been seeded
            if (context.Users.Any())
            {
                return;
            }

            // Seed Users
            var user1 = new User
            {
                name = "plantlover123"
            };
            var user2 = new User
            {
                name = "greenThumb"
            };

            context.Users.AddRange(user1, user2);
            context.SaveChanges();

            // Seed Plants
            var plant1 = new Plant
            {
                Name = "Aloe Vera",
                Species = "Aloe barbadensis",
                WateringFrequency = "Weekly",
                Image = "aloevera.jpg"
            };
            var plant2 = new Plant
            {
                Name = "Snake Plant",
                Species = "Sansevieria trifasciata",
                WateringFrequency = "Biweekly",
                Image = "snakeplant.jpg"
            };
            var plant3 = new Plant
            {
                Name = "Peace Lily",
                Species = "Spathiphyllum",
                WateringFrequency = "Weekly",
                Image = "peacelily.jpg"
            };

            context.Plants.AddRange(plant1, plant2, plant3);
            context.SaveChanges();

            // Seed UserPlant (Many-to-Many Relationship)
            var userPlant1 = new UserPlant
            {
                UserId = user1.Id,
                PlantId = plant1.Id,
                DateAssigned = DateTime.Now.AddDays(-30)
            };
            var userPlant2 = new UserPlant
            {
                UserId = user1.Id,
                PlantId = plant2.Id,
                DateAssigned = DateTime.Now.AddDays(-10)
            };
            var userPlant3 = new UserPlant
            {
                UserId = user2.Id,
                PlantId = plant1.Id,
                DateAssigned = DateTime.Now.AddDays(-20)
            };
            var userPlant4 = new UserPlant
            {
                UserId = user2.Id,
                PlantId = plant3.Id,
                DateAssigned = DateTime.Now.AddDays(-5)
            };

            context.UserPlants.AddRange(userPlant1, userPlant2, userPlant3, userPlant4);
            context.SaveChanges();
        }
    }
}
