using Microsoft.Data.SqlClient;
using SQL_CSharp.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_CSharp.repositories
{
    public class CustomerCountryRepository: ICustomerCountryRepository
    {
        public string ConnectionString { get; set; } = string.Empty;

        public void Add(CustomerCountry entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerCountry> CustomerCountByCountry()
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "SELECT Country, COUNT (*) AS Number FROM Customer GROUP BY Country ORDER BY Number DESC";
            using var command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                yield return new CustomerCountry(
                    
                    reader.GetString(0),
                    reader.GetInt32(1))
                    ;
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerCountry> GetAll()
        {
            throw new NotImplementedException();
        }

        public CustomerCountry GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(CustomerCountry entity)
        {
            throw new NotImplementedException();
        }
    }
}
