using Microsoft.EntityFrameworkCore;
using plantdrationAPI.Models;

public class PlantContext : DbContext
{
    // Parameterless constructor
    public PlantContext() { }

    // Constructor that takes DbContextOptions
    public PlantContext(DbContextOptions<PlantContext> options) : base(options)
    {
    }

    // DbSet properties for the entities
    public DbSet<User> Users { get; set; }
    public DbSet<Plant> Plants { get; set; }
    public DbSet<UserPlant> UserPlants { get; set; }

    // Configuring the model relationships and table names
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("User");
        modelBuilder.Entity<Plant>().ToTable("Plant");
        modelBuilder.Entity<UserPlant>().ToTable("UserPlant");

        // Many-to-Many relationship configuration
        modelBuilder.Entity<UserPlant>()
            .HasKey(up => new { up.UserId, up.PlantId });  // Composite primary key

        modelBuilder.Entity<UserPlant>()
            .HasOne(up => up.User)
            .WithMany(u => u.UserPlants)
            .HasForeignKey(up => up.UserId);

        modelBuilder.Entity<UserPlant>()
            .HasOne(up => up.Plant)
            .WithMany(p => p.UserPlants)
            .HasForeignKey(up => up.PlantId);
    }

    // Configuring the database connection
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=plantdrationDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
