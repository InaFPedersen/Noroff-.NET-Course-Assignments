using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLClientAssignment.Models
{
    internal class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        /// <summary>
        /// Writes the customer's: ID, first name, last name, country, postalcode, phone number and email 
        /// </summary>
        /// <param name="customer"></param>
        public void PrintCustomer(Customer customer)
        {
            Console.WriteLine($"--- {customer.CustomerID} {customer.FirstName} {customer.LastName} " +
                $"{customer.Country} {customer.PostalCode} {customer.Phone} {customer.Email} ---");
        }
    }
}
