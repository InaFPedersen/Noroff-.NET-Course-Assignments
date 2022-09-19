using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLClientAssignment.Models
{
    internal class CustomerGenre
    {
        public string FullName { get; set; }
        public string GenreName { get; set; }
        public int GenreNumber { get; set; }

        /// <summary>
        /// Writes the customer's full name, name of genre, and genre number
        /// </summary>
        /// <param name="customer"></param>
        public void PrintCustomer(CustomerGenre customer)
        {
            Console.WriteLine($"--- {customer.FullName} {customer.GenreName} {customer.GenreNumber}");
        }
    }
}
