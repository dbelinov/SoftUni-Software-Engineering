using Microsoft.EntityFrameworkCore;
using P02_FootballBetting.Data.Configurations;
using P02_FootballBetting.Data.Models;

namespace P02_FootballBetting.Data;

public class FootballBettingContext : DbContext
{
    public FootballBettingContext()
    {
        
    }

    public FootballBettingContext(DbContextOptions<FootballBettingContext> options)
    : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = "Server=.;Database=FootballBetting;User Id=sa;Password=VeryStr0ngP@ssw0rd;";

        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PlayerStatisticConfiguration());
        modelBuilder.ApplyConfiguration(new GameConfiguration());
        modelBuilder.ApplyConfiguration(new PlayerConfiguration());
        modelBuilder.ApplyConfiguration(new TeamConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Bet> Bets { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<PlayerStatistic> PlayersStatistics { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Town> Towns { get; set; }
    public DbSet<User> Users { get; set; }
}