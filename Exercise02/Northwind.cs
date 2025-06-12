using Microsoft.EntityFrameworkCore; // EF Core base classes
using System.IO; // For working with file paths
using System; // For Environment.CurrentDirectory

namespace Packt.Shared
{
    // This class is our gateway to the database
    public class Northwind : DbContext
    {
        // This represents the Customers table in the database
        public DbSet<Customer> Customers { get; set; }

        // Set up the connection to the SQLite database file
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Build the path to the Northwind.db file in the current directory
            string dbPath = Path.Combine(Environment.CurrentDirectory, "Northwind.db");

            // Tell EF Core to use SQLite with our file path
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}
