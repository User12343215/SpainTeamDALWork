using Microsoft.EntityFrameworkCore;

using UnitEFTest.Entities;

namespace UnitEFTest
{
    public class AppDbContext : DbContext
    {

        private static string _connectionString = @"Data Source=LINK\\SQLEXPRESS;Initial Catalog=FootballTeam;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;";


        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
