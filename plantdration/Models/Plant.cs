using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace plantdration.Models
{
    public class Plant : ObservableObject
    {
        private int id;
        private string name = string.Empty;
        private string species = string.Empty;
        private int wateringFrequencyInDays;
        private string sunlightRequirement = string.Empty;
        private double heightInCentimeters;
        private double growthRateInCmPerYear;
        private DateTime lastWatered;
        private bool isIndoorPlant;
        private string soilType = string.Empty;
        private double minTemperature;
        private string photoUrl = string.Empty;

        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Species
        {
            get => species;
            set => SetProperty(ref species, value);
        }

        public int WateringFrequencyInDays
        {
            get => wateringFrequencyInDays;
            set => SetProperty(ref wateringFrequencyInDays, value);
        }

        public string SunlightRequirement
        {
            get => sunlightRequirement;
            set => SetProperty(ref sunlightRequirement, value);
        }

        public double HeightInCentimeters
        {
            get => heightInCentimeters;
            set => SetProperty(ref heightInCentimeters, value);
        }

        public double GrowthRateInCmPerYear
        {
            get => growthRateInCmPerYear;
            set => SetProperty(ref growthRateInCmPerYear, value);
        }

        public DateTime LastWatered
        {
            get => lastWatered;
            set => SetProperty(ref lastWatered, value);
        }

        public bool IsIndoorPlant
        {
            get => isIndoorPlant;
            set => SetProperty(ref isIndoorPlant, value);
        }

        public string SoilType
        {
            get => soilType;
            set => SetProperty(ref soilType, value);
        }

        public double MinTemperature
        {
            get => minTemperature;
            set => SetProperty(ref minTemperature, value);
        }

        public string PhotoUrl
        {
            get => photoUrl;
            set => SetProperty(ref photoUrl, value);
        }

        public Plant(int id, string name, string species, int wateringFrequencyInDays, string sunlightRequirement, double heightInCentimeters, double growthRateInCmPerYear, DateTime lastWatered, bool isIndoorPlant, string soilType, double minTemperature, string photoUrl)
        {
            Id = id;
            Name = name;
            Species = species;
            WateringFrequencyInDays = wateringFrequencyInDays;
            SunlightRequirement = sunlightRequirement;
            HeightInCentimeters = heightInCentimeters;
            GrowthRateInCmPerYear = growthRateInCmPerYear;
            LastWatered = lastWatered;
            IsIndoorPlant = isIndoorPlant;
            SoilType = soilType;
            MinTemperature = minTemperature;
            PhotoUrl = photoUrl;
        }
    }
}
