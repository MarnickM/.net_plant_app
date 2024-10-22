namespace plantdrationAPI.Models
{
    public class Plant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string WateringFrequency { get; set; }
        public string Image { get; set; }
        // a plant belongs to a user, add the foreign key
        public int UserId { get; set; }
        // a plant belongs to a user, add the navigation property
        public User? User { get; set; }
    }
}
