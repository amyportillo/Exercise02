using System.ComponentModel.DataAnnotations; // Needed for things like [Key]

namespace Packt.Shared
{
    public class Customer
    {
        // This is the primary key for the Customer table
        [Key]
        public string CustomerID { get; set; }

        // The name of the company
        public string CompanyName { get; set; }

        // The city where the customer is located
        public string City { get; set; }
    }
}
