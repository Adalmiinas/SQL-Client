using Microsoft.Data.SqlClient;
using SQL_CSharp.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_CSharp.repositories
{
    public class CustomerSpenderRepository : ICustomerSpenderRepository
    {
        public string ConnectionString { get; set; } = string.Empty;

        public void Add(CustomerSpender entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return customers spending descending from the highest.
        /// </summary>
        /// <returns>IEnumerable<CustomerSpender></returns>
        public IEnumerable<CustomerSpender> CustomerSpendingById()
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "SELECT CustomerId, SUM(Total) AS TotalSales FROM Invoice GROUP BY CustomerId ORDER BY TotalSales DESC;";
            using var command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                yield return new CustomerSpender(

                    reader.GetInt32(0),
                    reader.GetDecimal(1))
                    ;
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerSpender> GetAll()
        {
            throw new NotImplementedException();
        }

        public CustomerSpender GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(CustomerSpender entity)
        {
            throw new NotImplementedException();
        }
    }
}
