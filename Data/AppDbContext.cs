using Microsoft.EntityFrameworkCore;

// Importing all model folders
using vogels_api.Models.Users;
using vogels_api.Models.Trees;
using vogels_api.Models.Birdhouses;
using vogels_api.Models.Laws;
using vogels_api.Models.Ministers;
using vogels_api.Models.Ministries;
using vogels_api.Models.Workers;

namespace vogels_api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // User table
    public DbSet<User> Users { set; get; }

    // Law tables
    public DbSet<LawBlueprint> LawBlueprints { set; get; }
    public DbSet<Law> Laws { set; get; }

    // Ministry tables
    public DbSet<Ministry> Ministries { set; get; }

    // Minister tables
    public DbSet<MinisterBlueprint> MinisterBlueprints { set; get; }
    public DbSet<Minister> Ministers { set; get; }

    // Worker tables
    public DbSet<Worker> Workers { set; get; }
    public DbSet<WorkerBlueprint> WorkerBlueprints { set; get; }
    
    // Tree tables
    public DbSet<TreeBlueprint> TreeBlueprints { set; get; }
    public DbSet<Tree> Trees { set; get; }

    // Birdhouse tables
    public DbSet<BirdhouseBlueprint> BirdHouseBlueprints { set; get; }
    public DbSet<Birdhouse> Birdhouses { set; get; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity => { entity.HasIndex(e => e.Email).IsUnique(); });
    }
}