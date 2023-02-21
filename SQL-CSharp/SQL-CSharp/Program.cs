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
            var customerByID = customerRepository.GetById(3);
            var customerByName = customerRepository.GetCustomerByName("an");



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
            Console.WriteLine("\n" + customerByID.id + ":" + customerByID.firstname + "\t" + customerByID.lastname + "\t" + customerByID.country + "\t" + customerByID.postalcode + "\t" + customerByID.phone + "\t" + customerByID.email);

            foreach (var customer in customerByName)
            {
                Console.Write(customer.id + ": \t ");
                Console.Write(customer.firstname + "\t");
                Console.Write(customer.lastname + "\t");
                Console.Write(customer.country + "\t");
                Console.Write(customer.postalcode + " \t");
                Console.Write(customer.phone + " \t");
                Console.WriteLine(customer.email);
            }
            //Console.WriteLine("\n" + customerByName.id + ":" + customerByName.firstname + "\t" + customerByName.lastname + "\t" + customerByName.country + "\t" + customerByName.postalcode + "\t" + customerByName.phone + "\t" + customerByName.email);
        }
        static string GetConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "N-FI-01-9981\\SQLEXPRESS";
            builder.InitialCatalog = "Chinook";
            builder.IntegratedSecurity= true;
            builder.TrustServerCertificate = true;

            return builder.ConnectionString;
        }
    }
}