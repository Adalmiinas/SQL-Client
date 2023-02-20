using Microsoft.Data.SqlClient;
using SQL_CSharp.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_CSharp.repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public string ConnectionString { get; set; } = string.Empty;
        public void Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

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
                    //reader.GetString(4),
                    postalCode,
                    phoneNumber,
                    //reader.GetString(5),
                    reader.GetString(6)
                    );
            }
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public string GetCustomerById(int customerDd)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
