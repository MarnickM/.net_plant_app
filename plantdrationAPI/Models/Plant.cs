namespace plantdrationAPI.Models
{
    public class Plant
    {
        public int Id { get; set; }
        public string tag { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Species { get; set; } = string.Empty;
        public int WateringFrequencyInDays { get; set; }
        public string SunlightRequirement { get; set; } = string.Empty;
        public double HeightInCentimeters { get; set; }
        public double GrowthRateInCmPerYear { get; set; }
        public DateTime LastWatered { get; set; }
        public bool IsIndoorPlant { get; set; }
        public string SoilType { get; set; } = string.Empty;
        public double MinTemperature { get; set; }
        public string PhotoUrl { get; set; } = string.Empty;

        // A plant has many users, through the association table
        public List<UserPlant> UserPlants { get; set; }
    }
}
