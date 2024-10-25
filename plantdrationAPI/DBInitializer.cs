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
                Name = "Chrysant",
                Species = "Chrysanthemum morifolium",
                WateringFrequencyInDays = 7, // Weekly
                SunlightRequirement = "Volle zon tot gedeeltelijke schaduw",
                HeightInCentimeters = 60,
                GrowthRateInCmPerYear = 20, // Example value, modify as needed
                LastWatered = DateTime.Now,
                IsIndoorPlant = false,
                SoilType = "Goed doorlatende grond",
                MinTemperature = 15,
                PhotoUrl = "chrysanthemum.jpg" // Placeholder image URL
            };

            var plant2 = new Plant
            {
                Name = "Vetplant",
                Species = "Crassula muscosa",
                WateringFrequencyInDays = 14, // Biweekly
                SunlightRequirement = "Volle zon tot gedeeltelijke schaduw",
                HeightInCentimeters = 30,
                GrowthRateInCmPerYear = 15, // Example value, modify as needed
                LastWatered = DateTime.Now,
                IsIndoorPlant = true,
                SoilType = "Cactusmix",
                MinTemperature = 10,
                PhotoUrl = "crassula_muscosa.jpg" // Placeholder image URL
            };

            var plant3 = new Plant
            {
                Name = "Kruipende Crassula",
                Species = "Crassula perforata",
                WateringFrequencyInDays = 14,
                SunlightRequirement = "Volle zon",
                HeightInCentimeters = 30,
                GrowthRateInCmPerYear = 15, // Example value, modify as needed
                LastWatered = DateTime.Now,
                IsIndoorPlant = true,
                SoilType = "Cactusmix",
                MinTemperature = 10,
                PhotoUrl = "crassula_perforata.jpg" // Placeholder image URL
            };

            var plant4 = new Plant
            {
                Name = "Euphorbia",
                Species = "Euphorbia nivulia",
                WateringFrequencyInDays = 14,
                SunlightRequirement = "Volle zon",
                HeightInCentimeters = 50,
                GrowthRateInCmPerYear = 10, // Example value, modify as needed
                LastWatered = DateTime.Now,
                IsIndoorPlant = false,
                SoilType = "Zanderige, goed doorlatende grond",
                MinTemperature = 10,
                PhotoUrl = "euphorbia_nivulia.jpg" // Placeholder image URL
            };

            var plant5 = new Plant
            {
                Name = "Graslelie",
                Species = "Chlorophytum comosum",
                WateringFrequencyInDays = 7,
                SunlightRequirement = "Indirecte zon",
                HeightInCentimeters = 60,
                GrowthRateInCmPerYear = 30, // Example value, modify as needed
                LastWatered = DateTime.Now,
                IsIndoorPlant = true,
                SoilType = "Goed doorlatende potgrond",
                MinTemperature = 10,
                PhotoUrl = "chlorophytum_comosum.jpg" // Placeholder image URL
            };

            var plant6 = new Plant
            {
                Name = "Orchidee",
                Species = "Orchidaceae",
                WateringFrequencyInDays = 7, // Every 7-10 days
                SunlightRequirement = "Indirecte zon",
                HeightInCentimeters = 60, // Varies widely
                GrowthRateInCmPerYear = 5, // Example value, modify as needed
                LastWatered = DateTime.Now,
                IsIndoorPlant = true,
                SoilType = "Orchideemix (schors)",
                MinTemperature = 20,
                PhotoUrl = "orchidaceae.jpg" // Placeholder image URL
            };

            var plant7 = new Plant
            {
                Name = "Kamchatka Steenkruid",
                Species = "Phedimus kamtschaticus",
                WateringFrequencyInDays = 21,
                SunlightRequirement = "Volle zon",
                HeightInCentimeters = 30,
                GrowthRateInCmPerYear = 10, // Example value, modify as needed
                LastWatered = DateTime.Now,
                IsIndoorPlant = false,
                SoilType = "Goed doorlatende grond",
                MinTemperature = 5,
                PhotoUrl = "phedimus_kamtschaticus.jpg" // Placeholder image URL
            };

            var plant8 = new Plant
            {
                Name = "Hernandez' Steenkruid",
                Species = "Sedum hernandezii",
                WateringFrequencyInDays = 21,
                SunlightRequirement = "Volle zon",
                HeightInCentimeters = 15,
                GrowthRateInCmPerYear = 5, // Example value, modify as needed
                LastWatered = DateTime.Now,
                IsIndoorPlant = true,
                SoilType = "Cactusmix",
                MinTemperature = 10,
                PhotoUrl = "sedum_hernandezii.jpg" // Placeholder image URL
            };

            var plant9 = new Plant
            {
                Name = "Balcactus",
                Species = "Tephrocactus verschaffeltii",
                WateringFrequencyInDays = 21,
                SunlightRequirement = "Volle zon",
                HeightInCentimeters = 40,
                GrowthRateInCmPerYear = 3, // Example value, modify as needed
                LastWatered = DateTime.Now,
                IsIndoorPlant = false,
                SoilType = "Cactusmix",
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
