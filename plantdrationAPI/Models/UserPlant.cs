namespace plantdrationAPI.Models
{
    public class UserPlant
    {
        public int UserId { get; set; }
        public User? User { get; set; }

        public int PlantId { get; set; }
        public Plant? Plant { get; set; }
        public DateTime DateAssigned { get; set; }
        public DateTime LastWatered { get; set; }
        public string PhotoPath { get; set; }
    }
}
