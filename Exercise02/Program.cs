using System;
using System.Linq; // Gives us LINQ methods like Where, Select, etc.
using Packt.Shared; // Our shared data models (Customer, Northwind)
using static System.Console; // So we can write shorter Console commands

namespace Exercise02
{
    class Program
    {
        static void Main()
        {
            // Create a database context to connect to Northwind
            using (var db = new Northwind())
            {
                // Grab all the distinct cities customers live in and sort them alphabetically
                var cities = db.Customers
                               .Select(c => c.City)
                               .Distinct()
                               .OrderBy(c => c)
                               .ToList();

                // Show the user a list of all available cities to choose from
                WriteLine("Available cities:");
                WriteLine(string.Join(", ", cities));
                WriteLine(); // Add an extra blank line for spacing

                // Ask the user to type a city name
                Write("Enter the name of a city: ");
                string city = ReadLine();

                // Look up all customers in the city the user entered
                var customers = db.Customers
                                  .Where(c => c.City == city) // Filter to just the selected city
                                  .OrderBy(c => c.CompanyName) // Sort the results by company name
                                  .Select(c => c.CompanyName) // Just get the company names
                                  .ToList();

                WriteLine(); // Extra spacing

                // Check if we found any customers
                if (customers.Any())
                {
                    // Show how many customers were found and list their company names
                    WriteLine($"There are {customers.Count} customers in {city}:");
                    foreach (var name in customers)
                    {
                        WriteLine(name); // Print each company name
                    }
                }
                else
                {
                    // If no customers were found, let the user know
                    WriteLine($"No customers found in {city}.");
                }
            }
        }
    }
}
