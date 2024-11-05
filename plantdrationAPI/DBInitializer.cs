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
                Name = "Marnick"
            };
            var user2 = new User
            {
                Name = "Sen"
            };

            context.Users.AddRange(user1, user2);
            context.SaveChanges();

            // Seed Plants
            var plant1 = new Plant
            {
                Name = "Chrysanthemum",
                tag = "chrysant",
                Species = "Chrysanthemum morifolium",
                WateringFrequencyInDays = 7, // Weekly
                SunlightRequirement = "Full sun to partial shade",
                HeightInCentimeters = 60,
                GrowthRateInCmPerYear = 20, // Example value, modify as needed
                /*LastWatered = DateTime.Now,*/
                IsIndoorPlant = false,
                SoilType = "Well-draining soil",
                MinTemperature = 15,
                PhotoUrl = "chrysanthemum.jpg" // Placeholder image URL
            };

            var plant2 = new Plant
            {
                Name = "Succulent",
                tag = "crassulamuscosa",
                Species = "Crassula muscosa",
                WateringFrequencyInDays = 14, // Biweekly
                SunlightRequirement = "Full sun to partial shade",
                HeightInCentimeters = 30,
                GrowthRateInCmPerYear = 15, // Example value, modify as needed
                /*LastWatered = DateTime.Now,*/
                IsIndoorPlant = true,
                SoilType = "Cactus mix",
                MinTemperature = 10,
                PhotoUrl = "crassula_muscosa.jpg" // Placeholder image URL
            };

            var plant3 = new Plant
            {
                Name = "Creeping Crassula",
                tag = "crassulaperforata",
                Species = "Crassula perforata",
                WateringFrequencyInDays = 14,
                SunlightRequirement = "Full sun",
                HeightInCentimeters = 30,
                GrowthRateInCmPerYear = 15, // Example value, modify as needed
                /*LastWatered = DateTime.Now,*/
                IsIndoorPlant = true,
                SoilType = "Cactus mix",
                MinTemperature = 10,
                PhotoUrl = "crassula_perforata.jpg" // Placeholder image URL
            };

            var plant4 = new Plant
            {
                Name = "Euphorbia",
                tag = "euphorbianivulia",
                Species = "Euphorbia nivulia",
                WateringFrequencyInDays = 14,
                SunlightRequirement = "Full sun",
                HeightInCentimeters = 50,
                GrowthRateInCmPerYear = 10, // Example value, modify as needed
                /*LastWatered = DateTime.Now,*/
                IsIndoorPlant = false,
                SoilType = "Sandy, well-draining soil",
                MinTemperature = 10,
                PhotoUrl = "euphorbia_nivulia.jpg" // Placeholder image URL
            };

            var plant5 = new Plant
            {
                Name = "Spider Plant",
                tag = "graslelie",
                Species = "Chlorophytum comosum",
                WateringFrequencyInDays = 7,
                SunlightRequirement = "Indirect sunlight",
                HeightInCentimeters = 60,
                GrowthRateInCmPerYear = 30, // Example value, modify as needed
                /*LastWatered = DateTime.Now,*/
                IsIndoorPlant = true,
                SoilType = "Good potting soil",
                MinTemperature = 10,
                PhotoUrl = "chlorophytum_comosum.jpg" // Placeholder image URL
            };

            var plant6 = new Plant
            {
                Name = "Orchid",
                tag = "orchidaceae",
                Species = "Orchidaceae",
                WateringFrequencyInDays = 7, // Every 7-10 days
                SunlightRequirement = "Indirect sunlight",
                HeightInCentimeters = 60, // Varies widely
                GrowthRateInCmPerYear = 5, // Example value, modify as needed
                /*LastWatered = DateTime.Now,*/
                IsIndoorPlant = true,
                SoilType = "Orchid mix (bark)",
                MinTemperature = 20,
                PhotoUrl = "orchidaceae.jpg" // Placeholder image URL
            };

            var plant7 = new Plant
            {
                Name = "Kamchatka Stonecrop",
                tag = "phedimuskamtschaticus",
                Species = "Phedimus kamtschaticus",
                WateringFrequencyInDays = 21,
                SunlightRequirement = "Full sun",
                HeightInCentimeters = 30,
                GrowthRateInCmPerYear = 10, // Example value, modify as needed
                /*LastWatered = DateTime.Now,*/
                IsIndoorPlant = false,
                SoilType = "Well-draining soil",
                MinTemperature = 5,
                PhotoUrl = "phedimus_kamtschaticus.jpg" // Placeholder image URL
            };

            var plant8 = new Plant
            {
                Name = "Hernandez' Stonecrop",
                tag = "sedumhernandezii",
                Species = "Sedum hernandezii",
                WateringFrequencyInDays = 21,
                SunlightRequirement = "Full sun",
                HeightInCentimeters = 15,
                GrowthRateInCmPerYear = 5, // Example value, modify as needed
                /*LastWatered = DateTime.Now,*/
                IsIndoorPlant = true,
                SoilType = "Cactus mix",
                MinTemperature = 10,
                PhotoUrl = "sedum_hernandezii.jpg" // Placeholder image URL
            };

            var plant9 = new Plant
            {
                Name = "Balacactus",
                tag = "tephrocactusverschaffeltii",
                Species = "Tephrocactus verschaffeltii",
                WateringFrequencyInDays = 21,
                SunlightRequirement = "Full sun",
                HeightInCentimeters = 40,
                GrowthRateInCmPerYear = 3, // Example value, modify as needed
                /*LastWatered = DateTime.Now,*/
                IsIndoorPlant = false,
                SoilType = "Cactus mix",
                MinTemperature = 10,
                PhotoUrl = "tephrocactus_verschaffeltii.jpg" // Placeholder image URL
            };

            context.Plants.AddRange(plant1, plant2, plant3, plant4, plant5, plant6, plant7, plant8, plant9);
            context.SaveChanges();

            // Seed UserPlant (Many-to-Many Relationship)
            var userPlant1 = new UserPlant
            {
                UserId = user1.Id,
                PlantId = plant1.Id,
                DateAssigned = DateTime.Now.AddDays(-30),
                LastWatered = DateTime.Now.AddDays(-7)
            };
            var userPlant2 = new UserPlant
            {
                UserId = user1.Id,
                PlantId = plant2.Id,
                DateAssigned = DateTime.Now.AddDays(-10),
                LastWatered = DateTime.Now.AddDays(-14)
            };
            var userPlant3 = new UserPlant
            {
                UserId = user2.Id,
                PlantId = plant1.Id,
                DateAssigned = DateTime.Now.AddDays(-20),
                LastWatered = DateTime.Now.AddDays(-7)
            };
            var userPlant4 = new UserPlant
            {
                UserId = user2.Id,
                PlantId = plant3.Id,
                DateAssigned = DateTime.Now.AddDays(-5),
                LastWatered = DateTime.Now.AddDays(-14)
            };

            context.UserPlants.AddRange(userPlant1, userPlant2, userPlant3, userPlant4);
            context.SaveChanges();
        }
    }
}
