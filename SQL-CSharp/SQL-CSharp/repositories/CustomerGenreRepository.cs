using Microsoft.Data.SqlClient;
using SQL_CSharp.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_CSharp.repositories
{
    public class CustomerGenreRepository : ICustomerGenreRepository
    {
        public string ConnectionString { get; set; } = string.Empty;

        public void Add(CustomerGenre entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns customers most popular genre.
        /// </summary>
        /// <returns>IEnumerable<CustomerGenre></returns>
        public IEnumerable<CustomerGenre> CustomerGenre()
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "SELECT CustomerId, MAX (Name) AS Genre FROM ( SELECT Invoice.CustomerId, Genre.Name AS Name FROM Invoice " +
              "JOIN InvoiceLine ON Invoice.InvoiceId = InvoiceLine.InvoiceId JOIN Track ON Track.TrackId = InvoiceLine.TrackId " +
              "JOIN Genre ON Track.GenreId = Genre.GenreId) AS InTable GROUP BY CustomerId ORDER BY CustomerId ASC;";
            using var command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                yield return new CustomerGenre(

                    reader.GetInt32(0),
                    reader.GetString(1));
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerGenre> GetAll()
        {
            throw new NotImplementedException();
        }

        public CustomerGenre GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(CustomerGenre entity)
        {
            throw new NotImplementedException();
        }
    }
}

