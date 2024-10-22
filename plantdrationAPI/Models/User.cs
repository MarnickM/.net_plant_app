namespace plantdrationAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        // a user has multiple plants, add the navigation property
        public List<Plant> Plants { get; set; }

    }
}
