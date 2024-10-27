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
        /*public async static Task<List<Plant>> GetPlantsAsync()
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
        }*/

        public static Plant? GetPlantByTag(string tag)
        {
            return new List<Plant>
    {
        new Plant
        {
            Id = 1,
            Tag = "chrysant",
            Name = "Chrysanthemum",
            Species = "Chrysanthemum morifolium",
            WateringFrequencyInDays = 7,
            SunlightRequirement = "Full sun to partial shade",
            HeightInCentimeters = 45.0,
            GrowthRateInCmPerYear = 15.0,
            LastWatered = DateTime.Now.AddDays(-3),
            IsIndoorPlant = false,
            SoilType = "Well-drained, fertile soil",
            MinTemperature = 15.0,
            PhotoUrl = "https://example.com/photos/chrysanthemum.jpg"
        },
        new Plant
        {
            Id = 2,
            Tag = "crassulamuscosa",
            Name = "Crassula Muscosa",
            Species = "Crassula muscosa",
            WateringFrequencyInDays = 14,
            SunlightRequirement = "Bright, indirect light",
            HeightInCentimeters = 15.0,
            GrowthRateInCmPerYear = 5.0,
            LastWatered = DateTime.Now.AddDays(-7),
            IsIndoorPlant = true,
            SoilType = "Well-drained, sandy soil",
            MinTemperature = 18.0,
            PhotoUrl = "https://example.com/photos/crassulamuscosa.jpg"
        },
        new Plant
        {
            Id = 3,
            Tag = "crassulaperforata",
            Name = "Crassula Perforata",
            Species = "Crassula perforata",
            WateringFrequencyInDays = 10,
            SunlightRequirement = "Bright, indirect light",
            HeightInCentimeters = 20.0,
            GrowthRateInCmPerYear = 10.0,
            LastWatered = DateTime.Now.AddDays(-5),
            IsIndoorPlant = true,
            SoilType = "Cactus mix",
            MinTemperature = 15.0,
            PhotoUrl = "https://example.com/photos/crassulaperforata.jpg"
        },
        new Plant
        {
            Id = 4,
            Tag = "euphorbianivulia",
            Name = "Euphorbia Nivulia",
            Species = "Euphorbia nivulia",
            WateringFrequencyInDays = 21,
            SunlightRequirement = "Full sun",
            HeightInCentimeters = 200.0,
            GrowthRateInCmPerYear = 10.0,
            LastWatered = DateTime.Now.AddDays(-20),
            IsIndoorPlant = false,
            SoilType = "Sandy, well-drained soil",
            MinTemperature = 20.0,
            PhotoUrl = "https://example.com/photos/euphorbianivulia.jpg"
        },
        new Plant
        {
            Id = 5,
            Tag = "graslelie",
            Name = "Spider Plant",
            Species = "Chlorophytum comosum",
            WateringFrequencyInDays = 7,
            SunlightRequirement = "Indirect sunlight",
            HeightInCentimeters = 25.0,
            GrowthRateInCmPerYear = 12.0,
            LastWatered = DateTime.Now.AddDays(-2),
            IsIndoorPlant = true,
            SoilType = "Loamy soil",
            MinTemperature = 15.0,
            PhotoUrl = "https://example.com/photos/spiderplant.jpg"
        },
        new Plant
        {
            Id = 6,
            Tag = "orchidaceae",
            Name = "Orchid",
            Species = "Orchidaceae",
            WateringFrequencyInDays = 7,
            SunlightRequirement = "Partial shade",
            HeightInCentimeters = 50.0,
            GrowthRateInCmPerYear = 8.0,
            LastWatered = DateTime.Now.AddDays(-5),
            IsIndoorPlant = true,
            SoilType = "Orchid mix",
            MinTemperature = 18.0,
            PhotoUrl = "https://example.com/photos/orchid.jpg"
        },
        new Plant
        {
            Id = 7,
            Tag = "phedimuskamtschaticus",
            Name = "Kamchatka Stonecrop",
            Species = "Phedimus kamtschaticus",
            WateringFrequencyInDays = 14,
            SunlightRequirement = "Full sun",
            HeightInCentimeters = 15.0,
            GrowthRateInCmPerYear = 4.0,
            LastWatered = DateTime.Now.AddDays(-10),
            IsIndoorPlant = false,
            SoilType = "Rocky or sandy soil",
            MinTemperature = 10.0,
            PhotoUrl = "https://example.com/photos/kamchatkastonecrop.jpg"
        },
        new Plant
        {
            Id = 8,
            Tag = "sedumhernandezii",
            Name = "Sedum Hernandezii",
            Species = "Sedum hernandezii",
            WateringFrequencyInDays = 10,
            SunlightRequirement = "Full sun",
            HeightInCentimeters = 10.0,
            GrowthRateInCmPerYear = 3.0,
            LastWatered = DateTime.Now.AddDays(-8),
            IsIndoorPlant = false,
            SoilType = "Cactus mix",
            MinTemperature = 15.0,
            PhotoUrl = "https://example.com/photos/sedumhernandezii.jpg"
        },
        new Plant
        {
            Id = 9,
            Tag = "tephrocactusverschaffeltii",
            Name = "Tephrocactus Verschaffeltii",
            Species = "Tephrocactus verschaffeltii",
            WateringFrequencyInDays = 21,
            SunlightRequirement = "Full sun",
            HeightInCentimeters = 15.0,
            GrowthRateInCmPerYear = 2.0,
            LastWatered = DateTime.Now.AddDays(-19),
            IsIndoorPlant = false,
            SoilType = "Sandy soil",
            MinTemperature = 20.0,
            PhotoUrl = "https://example.com/photos/tephrocactus.jpg"
        }
    }.FirstOrDefault(plant => plant.Tag == tag);
        }
    }
}
