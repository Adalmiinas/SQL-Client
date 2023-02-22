using Microsoft.Data.SqlClient;
using SQL_CSharp.models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SQL_CSharp.repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public string ConnectionString { get; set; } = string.Empty;

        //Adds new customer to the database.
        public void Add(Customer entity)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "INSERT INTO Customer (FirstName, LastName, Country, PostalCode, Phone, Email) VALUES(@FirstName, @LastName, @Country, @PostalCode, @Phone, @Email)";
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@FirstName", entity.firstname);
            command.Parameters.AddWithValue("@LastName", entity.lastname);
            command.Parameters.AddWithValue("@Country", entity.country);
            command.Parameters.AddWithValue("@PostalCode", entity.postalcode);
            command.Parameters.AddWithValue("@Phone", entity.phone);
            command.Parameters.AddWithValue("@Email", entity.email);
            command.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns all customers from the database.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Customer> GetAll()
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "SELECT CustomerID, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer";
            using var command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string postalCode = String.Empty;
                string phoneNumber = String.Empty;

                if (!reader.IsDBNull(4))
                {
                     postalCode = reader.GetString(4);
                }

                if (!reader.IsDBNull(5))
                {
                    phoneNumber = reader.GetString(5);
                }
                
                yield return new Customer(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    postalCode,
                    phoneNumber,
                    reader.GetString(6)
                    );
            }
        }

        /// <summary>
        /// Returns a customer by it's id.
        /// </summary>
        /// <param name="id">Gets id you want the search with</param>
        /// <returns>Customer</returns>
        public Customer GetById(int id)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer WHERE CustomerId = @CustomerId";
            using var commmand = new SqlCommand(sql, connection);
            commmand.Parameters.AddWithValue("@CustomerId", id);
            using var reader = commmand.ExecuteReader();

            var result = new Customer();

            while (reader.Read())
            {
                string postalCode = String.Empty;
                string phoneNumber = String.Empty;

                if (!reader.IsDBNull(4))
                {
                    postalCode = reader.GetString(4);
                }

                if (!reader.IsDBNull(5))
                {
                    phoneNumber = reader.GetString(5);
                }

                result = new Customer(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    postalCode,
                    phoneNumber,
                    reader.GetString(6)
                    );
            }
            return result;
        }

        /// <summary>
        /// Return customer by it's name
        /// </summary>
        /// <param name="customerName">Gets the name you want to search with</param>
        /// <returns> IEnumerable<Customer></returns>
        public IEnumerable<Customer> GetCustomerByName(string customerName)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = $"SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer WHERE FirstName LIKE '%{customerName}%' OR LastName LIKE '%{customerName}%'";
            using var commmand = new SqlCommand(sql, connection);
            commmand.Parameters.AddWithValue("@FirstName", customerName);
            using var reader = commmand.ExecuteReader();

            while (reader.Read())
            {
                string postalCode = String.Empty;
                string phoneNumber = String.Empty;

                if (!reader.IsDBNull(4))
                {
                    postalCode = reader.GetString(4);
                }

                if (!reader.IsDBNull(5))
                {
                    phoneNumber = reader.GetString(5);
                }

                yield return new Customer(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    postalCode,
                    phoneNumber,
                    reader.GetString(6)
                    );
            }
        }

        /// <summary>
        /// Updates customer
        /// </summary>
        /// <param name="entity">Gets a customer entity</param>
        public void Update(Customer entity)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "UPDATE Customer SET FirstName = @FirstName, LastName = @Lastname, Country = @Country," +
                "PostalCode = @PostalCode, Phone = @Phone, Email = @Email WHERE CustomerId = @CustomerId";
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@FirstName", entity.firstname);
            command.Parameters.AddWithValue("@LastName", entity.lastname);
            command.Parameters.AddWithValue("@Country", entity.country);
            command.Parameters.AddWithValue("@PostalCode", entity.postalcode);
            command.Parameters.AddWithValue("@Phone", entity.phone);
            command.Parameters.AddWithValue("@Email", entity.email);
            command.Parameters.AddWithValue("@CustomerId", entity.id);
            command.ExecuteNonQuery();

        }


        /// <summary>
        /// Returns a list of customers with the given limit and offset.
        /// </summary>
        /// <param name="offset">Starts from this point of the list</param>
        /// <param name="limit">How many customers you want to see</param>
        /// <returns>IEnumerable<Customer></returns>
        public IEnumerable<Customer> GetListOfCustomersWithLimitAndOffset(int offset, int limit)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = $"SELECT CustomerID, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer ORDER BY CustomerId OFFSET {offset} ROWS FETCH NEXT {limit} ROWS only";
            using var command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string postalCode = String.Empty;
                string phoneNumber = String.Empty;

                if (!reader.IsDBNull(4))
                {
                    postalCode = reader.GetString(4);
                }

                if (!reader.IsDBNull(5))
                {
                    phoneNumber = reader.GetString(5);
                }

                yield return new Customer(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    postalCode,
                    phoneNumber,
                    reader.GetString(6)
                    );
            }
        }
    }
}
