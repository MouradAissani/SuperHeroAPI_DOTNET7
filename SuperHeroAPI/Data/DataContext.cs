namespace SuperHeroAPI.Data;

public class DataDbContext : DbContext
{
    public DataDbContext(DbContextOptions<DataDbContext> options)
        : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=localhost;Database=superhero;" +
                                    "TrustServerCertificate=true;User Id=sa;Password=Pass@word;");
    }

    public DbSet<SuperHero> SuperHeroes { get; set; }
}