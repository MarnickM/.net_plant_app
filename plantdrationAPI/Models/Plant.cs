namespace plantdrationAPI.Models
{
    public class Plant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string WateringFrequency { get; set; }
        public string Image { get; set; }

        // A plant has many users, through the association table
        public List<UserPlant> UserPlants { get; set; }
    }
}
