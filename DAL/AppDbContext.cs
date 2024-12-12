using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        private string _connectionString = "Data Source=LINK\\SQLEXPRESS;Initial Catalog=FootballTeam;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;";

        public DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
