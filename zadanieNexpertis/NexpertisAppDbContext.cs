using Microsoft.EntityFrameworkCore;
using zadanieNexpertis.Entities;

namespace zadanieNexpertis
{
    public class NexpertisAppDbContext : DbContext
    {
        private string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=NexpertisAppDb;Trusted_Connection=True;";
        public DbSet<CurrencyData> Currencies { get; set; }
        public DbSet<User> Users { get; set; }  
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
