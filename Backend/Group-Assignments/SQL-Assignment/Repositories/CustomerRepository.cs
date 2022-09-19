using Microsoft.Data.SqlClient;
using SQLClientAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLClientAssignment.Repositories
{
    internal class CustomerRepository : ICustomerRepository
    {
        #region Obtain all customers
        /// <summary>
        /// Obtain all customers from database
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetAllCustomers()
        {
            List<Customer> customerList = new List<Customer>();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer";

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    connection.Open();
                    
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                
                                Customer customer = new Customer();
                                customer.CustomerID = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.LastName = reader.GetString(2);
                                customer.Country = reader.GetString(3);
                                customer.PostalCode = SqlNullChecker(reader, 4);
                                customer.Phone = SqlNullChecker(reader, 5);
                                customer.Email = reader.GetString(6);
                                customerList.Add(customer);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return customerList;
        }
        #endregion

        #region Customer country
        /// <summary>
        /// Obtain customers country
        /// </summary>
        /// <returns></returns>
        public List<CustomerCountry> GetAllCustomersByCountry()
        {
            List<CustomerCountry> customerList = new List<CustomerCountry>();
            string sql = "SELECT COUNT(CustomerId) as NumberOfCustomers, Country " +
                         "FROM CUSTOMER GROUP BY Country ORDER BY NumberOfCustomers DESC";

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    connection.Open();
                   
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerCountry customer = new CustomerCountry();
                                customer.NumberOfCustomers = reader.GetInt32(0);
                                customer.Country = reader.GetString(1);
                                customerList.Add(customer);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return customerList;
        }
        #endregion

        #region Get all Customers With Limit
        public List<Customer> GetAllCustomersWithLimit(int limit, int offset)
        {
            List<Customer> customerList = new List<Customer>();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email " +
                         "FROM Customer " +
                         "ORDER BY CustomerId " +
                         "OFFSET @offset ROWS " +
                         "FETCH NEXT @limit ROWS ONLY";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    connection.Open();
                    
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@limit", limit);
                        command.Parameters.AddWithValue("@offset", offset);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer customer = new Customer();
                                customer.CustomerID = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.LastName = reader.GetString(2);
                                customer.Country = reader.GetString(3);
                                customer.PostalCode = SqlNullChecker(reader, 4);
                                customer.Phone = SqlNullChecker(reader, 5);
                                customer.Email = reader.GetString(6);
                                customerList.Add(customer);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return customerList;
        }

        public Customer GetCustomer(int id)
        {
            Customer customer = new Customer();
            
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email " +
                         "FROM Customer WHERE CustomerId = @CustomerId";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    connection.Open();
                    
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerId", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customer.CustomerID = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.LastName = reader.GetString(2);
                                customer.Country = reader.GetString(3);
                                customer.PostalCode = SqlNullChecker(reader, 4);
                                customer.Phone = SqlNullChecker(reader, 5);
                                customer.Email = reader.GetString(6);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return customer;
        }
        #endregion

        #region Obtain Customers by name
        /// <summary>
        /// Check by customer name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Customer GetCustomerByName(string name)
        {
            Customer customer = new Customer();
            
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email " +
                         "FROM Customer WHERE FirstName LIKE @name";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    
                    connection.Open();
                    
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customer.CustomerID = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.LastName = reader.GetString(2);
                                customer.Country = reader.GetString(3);
                                customer.PostalCode = SqlNullChecker(reader, 4);
                                customer.Phone = SqlNullChecker(reader, 5);
                                customer.Email = reader.GetString(6);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return customer;
        }
        #endregion

        #region Add new customer
        /// <summary>
        /// Add new customers
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public bool AddNewCustomer(Customer customer)
        {
            bool result = false;
            string sql = "INSERT INTO Customer(FirstName, LastName, Country, PostalCode, Phone, Email) " +
                "VALUES (@FirstName, @LastName, @Country, @PostalCode, @Phone, @Email)";

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    connection.Open();
                    
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        command.Parameters.AddWithValue("@LastName", customer.LastName);
                        command.Parameters.AddWithValue("@Country", customer.Country);
                        command.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        command.Parameters.AddWithValue("@Phone", customer.Phone);
                        command.Parameters.AddWithValue("@Email", customer.Email);

                        
                        result = command.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
        #endregion

        #region Delete customers
        /// <summary>
        /// Delete a existing
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update customer
        /// <summary>
        /// Update existing customer
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool UpdateCustomer(Customer customer, int id)
        {
            bool result = false;
            string sql = "UPDATE Customer " +
                "SET FirstName = @FirstName, LastName = @LastName, Country = @Country, " +
                "PostalCode = @PostalCode, Phone = @Phone, Email = @Email " +
                "WHERE CustomerId = @id";

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    connection.Open();
                    
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        command.Parameters.AddWithValue("@LastName", customer.LastName);
                        command.Parameters.AddWithValue("@Country", customer.Country);
                        command.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        command.Parameters.AddWithValue("@Phone", customer.Phone);
                        command.Parameters.AddWithValue("@Email", customer.Email);

                        command.Parameters.AddWithValue("@id", id);

                        
                        result = command.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
        #endregion

        #region Customer by Spending
        /// <summary>
        /// Obtain all customer by spending
        /// </summary>
        /// <returns></returns>
        public List<CustomerSpender> GetAllCustomersBySpender()
        {
            List<CustomerSpender> customerList = new List<CustomerSpender>();
            string sql = "SELECT TOP(10) CONCAT(FirstName, ' ', LastName) AS FullName, SUM(Total) as TotalSum " +
                         "FROM Customer, Invoice " +
                         "WHERE Customer.CustomerId = Invoice.CustomerId " +
                         "GROP BY FirstName, LastName " +
                         "ORDER BY TotalSum DESC";

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    connection.Open();
                    
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerSpender customer = new CustomerSpender();
                                customer.FullName = reader.GetString(0);
                                customer.Total = (double)reader.GetDecimal(1);
                                customerList.Add(customer);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return customerList;
        }
        #endregion

        #region Customer by Genre
        /// <summary>
        /// Customer by Genre
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CustomerGenre GetCustomerGenre(int id)
        {
            CustomerGenre customer = new CustomerGenre();
            
            string sql = "SELECT TOP(1) CONCAT(FirstName, ' ', LastName) AS FullName, Genre.Name, COUNT(*) AS TimesBought " +
                         "FROM Customer, Invoice, InvoiceLine, Track, Genre " +
                         "WHERE Customer.CustomerId = Invoice.CustomerId " +
                         "AND Invoice.InvoiceId = InvoiceLine.InvoiceId " +
                         "AND InvoiceLine.TrackId = Track.TrackId " +
                         "AND Track.GenreId = Genre.GenreId " +
                         "AND Customer.CustomerId = @id " +
                         "GROUP BY FirstName, LastName, Genre.Name " +
                         "ORDER BY TimesBought DESC";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    connection.Open();
                    
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customer.FullName = reader.GetString(0);
                                customer.GenreName = reader.GetString(1);
                                customer.GenreNumber = reader.GetInt32(2);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return customer;
        }
        #endregion

        #region SQL Null check
        /// <summary>
        /// SQL null check
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string SqlNullChecker(SqlDataReader reader, int index)
        {
            return !reader.IsDBNull(index) ? reader.GetString(index) : String.Empty;
        }
        #endregion
    }
}
