namespace plantdrationAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string name { get; set; }

        // A user has many plants, through the association table
        public List<UserPlant> UserPlants { get; set; }
    }
}
