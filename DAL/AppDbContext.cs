using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class AppDbContext : DbContext
    {

        private static string _connectionString;

        static AppDbContext()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json")
                .Build();

            _connectionString = configuration.GetConnectionString("FirstConnection");
        }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Match> Matches { get; set; }

        public DbSet<Goal> Goals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
