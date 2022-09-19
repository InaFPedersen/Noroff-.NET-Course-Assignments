using SQLClientAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLClientAssignment.Repositories
{
    internal interface ICustomerRepository
    {
        public Customer GetCustomer(int id);
        public Customer GetCustomerByName(string name);
        public CustomerGenre GetCustomerGenre(int id);
        public List<Customer> GetAllCustomers();
        public List<Customer> GetAllCustomersWithLimit(int limit, int offset);
        public List<CustomerCountry> GetAllCustomersByCountry();
        public List<CustomerSpender> GetAllCustomersBySpender();
        public bool AddNewCustomer(Customer customer);
        public bool UpdateCustomer(Customer customer, int id);
        public bool DeleteCustomer(int id);
    }
}
