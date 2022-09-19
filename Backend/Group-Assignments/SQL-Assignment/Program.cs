using SQLClientAssignment.Models;
using SQLClientAssignment.Repositories;
using System;
using System.Collections.Generic;

namespace SQLClientAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Get all customers
            ICustomerRepository repository = new CustomerRepository();
            TestSelectAll(repository);
        }

        #region Customer
        /// <summary>
        /// Test with all customers selected
        /// </summary>
        /// <param name="repository"></param>
        static void TestSelectAll(ICustomerRepository repository)
        {
            PrintCustomers(repository.GetAllCustomers());
        }

        /// <summary>
        /// Adding a new customer
        /// </summary>
        /// <param name="repository"></param>
        static void TestInsert(ICustomerRepository repository)
        {
            Customer test = new Customer()
            {
                FirstName = "Sondre",
                LastName = "Nygard",
                Country = "Norway",
                PostalCode = "4027",
                Phone = "12345678",
                Email = "sondre@test.no"
            };
            if (repository.AddNewCustomer(test))
            {
                Console.WriteLine("Inserted new customer");
            }
            else
            {
                Console.WriteLine("Insert failed");
            }
        }

        /// <summary>
        /// Test updating customer
        /// </summary>
        /// <param name="repository"></param>
        static void TestUpdate(ICustomerRepository repository)
        {
            Customer test = new Customer()
            {
                FirstName = "fafafaf",
                LastName = "Skogsasfasfasftad",
                Country = "4343dscdsf",
                PostalCode = "fdfsdfds",
                Phone = "23fsdfds",
                Email = "Sindre@test.no"
            };
            if (repository.UpdateCustomer(test, 5))
            {
                Console.WriteLine("Updated customer");
            }
            else
            {
                Console.WriteLine("Update failed");
            }
        }

        /// <summary>
        /// selected customer by index
        /// </summary>
        /// <param name="repository"></param>
        static void TestSelect(ICustomerRepository repository)
        {
            int index = 5;
            Customer test = new Customer();


            test.PrintCustomer(repository.GetCustomer(index));
        }

        /// <summary>
        /// Obtain by selected name
        /// </summary>
        /// <param name="repository"></param>
        static void TestSelectByName(ICustomerRepository repository)
        {
            string name = "Sander";
            Customer test = new Customer()
            {
                FirstName = name,
            };

            test.PrintCustomer(repository.GetCustomerByName("Sander"));
        }

        /// <summary>
        /// Selected customers with limit
        /// </summary>
        /// <param name="repository"></param>
        static void TestSelectAllWithLimit(ICustomerRepository repository)
        {
            PrintCustomers(repository.GetAllCustomersWithLimit(10, 2));
        }

        /// <summary>
        /// Writes customers 
        /// </summary>
        /// <param name="customers"></param>
        static void PrintCustomers(IEnumerable<Customer> customers)
        {
            foreach (Customer customer in customers)
            {
                customer.PrintCustomer(customer);
            }
        }
        #endregion

        #region By spender
        /// <summary>
        /// Writes customer's by spending
        /// </summary>
        /// <param name="customers"></param>
        static void PrintCustomersBySpender(IEnumerable<CustomerSpender> customers)
        {
            foreach (CustomerSpender customer in customers)
            {
                PrintCustomerBySpender(customer);
            }
        }

        /// <summary>
        /// Writes customers by spender
        /// </summary>
        /// <param name="customer"></param>
        static void PrintCustomerBySpender(CustomerSpender customer)
        {
            Console.WriteLine($"--- {customer.FullName} {customer.Total} ---");
        }

        /// <summary>
        /// Top spender from all customers
        /// </summary>
        /// <param name="repository"></param>
        static void TestSelectTopSpenders(ICustomerRepository repository)
        {
            PrintCustomersBySpender(repository.GetAllCustomersBySpender());
        }
        #endregion

        #region By Genre
        /// <summary>
        /// Writes customers by genre
        /// </summary>
        /// <param name="customers"></param>
        static void PrintCustomersByGenre(IEnumerable<CustomerGenre> customers)
        {
            foreach (CustomerGenre customer in customers)
            {
                customer.PrintCustomer(customer);
            }
        }

        /// <summary>
        /// Testing genre
        /// </summary>
        /// <param name="repository"></param>
        static void TestGenre(ICustomerRepository repository)
        {
            int index = 1;
            CustomerGenre test = new CustomerGenre();


            test.PrintCustomer(repository.GetCustomerGenre(index));
        }
        #endregion

        #region By country
        /// <summary>
        /// Writes customer's country 
        /// </summary>
        /// <param name="customers"></param>
        static void PrintCustomersCountry(IEnumerable<CustomerCountry> customers)
        {
            foreach (CustomerCountry customer in customers)
            {
                PrintCustomerCountry(customer);
            }
        }

        /// <summary>
        /// All customers by contry
        /// </summary>
        /// <param name="repository"></param>
        static void TestSelectAllByCountry(ICustomerRepository repository)
        {
            PrintCustomersCountry(repository.GetAllCustomersByCountry());
        }

        /// <summary>
        /// Writes customers from same country
        /// </summary>
        /// <param name="customer"></param>
        static void PrintCustomerCountry(CustomerCountry customer)
        {
            Console.WriteLine($"--- {customer.Country} {customer.NumberOfCustomers} ---");
        }
        #endregion
    }
}
