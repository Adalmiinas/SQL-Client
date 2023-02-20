using Microsoft.Data.SqlClient;
using SQL_CSharp.repositories;

namespace SQL_CSharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var customerRepository = new CustomerRepository() { ConnectionString = GetConnectionString()};
            var allCustomers = customerRepository.GetAll();

            foreach (var customer in allCustomers)
            {
                Console.Write(customer.id + ": \t ");
                Console.Write(customer.firstname + "\t");
                Console.Write(customer.lastname + "\t");
                Console.Write(customer.country + "\t");
                Console.Write(customer.postalcode + " \t");
                Console.Write(customer.phone + " \t");
                Console.WriteLine(customer.email);
            }
            
        }
        static string GetConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "N-FI-01-3756\\SQLEXPRESS01";
            builder.InitialCatalog = "Chinook";
            builder.IntegratedSecurity= true;
            builder.TrustServerCertificate = true;

            return builder.ConnectionString;
        }
    }
    
}