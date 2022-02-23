using Microsoft.EntityFrameworkCore;

// Importing all model folders
using vogels_api.Models.User;
using vogels_api.Models.Tree;
using vogels_api.Models.Birdhouse;
using vogels_api.Models.Law;
using vogels_api.Models.Minister;

namespace vogels_api.Data;

public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { set; get; }
    
    // Law tables
    public DbSet<LawBlueprint> LawBlueprints { set; get; }
    public DbSet<Law> Law { set; get; }

    // Minister tables
    public DbSet<Ministry> Ministry { set; get; }
    public DbSet<MinisterBlueprint> MinisterBlueprints { set; get; }
    public DbSet<Minister> Ministers { set; get; }

    // Tree tables
    public DbSet<TreeBlueprint> TreeBlueprints { set; get; }
    public DbSet<Tree> Trees { set; get; }
    
    // Birdhouse tables
    public DbSet<BirdhouseBlueprint> BirdHouseBlueprints { set; get; }
    public DbSet<Birdhouse> Birdhouses { set; get; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<User>(entity => { entity.HasIndex(e => e.Email).IsUnique(); });
    }
}