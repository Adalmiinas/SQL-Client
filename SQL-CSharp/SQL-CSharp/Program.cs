using Microsoft.Data.SqlClient;
using SQL_CSharp.models;
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
            var getCustomerListWithLimitAndOffset = customerRepository.GetListOfCustomersWithLimitAndOffset(5, 24);
            var customerCountryRepository = new CustomerCountryRepository() { ConnectionString = GetConnectionString()};
            var customerCountByCountry = customerCountryRepository.CustomerCountByCountry();

            var customerSpendingRepository = new CustomerSpenderRepository() { ConnectionString = GetConnectionString() };
            var customerSpending = customerSpendingRepository.CustomerSpendingById();

            var customerGenreRepostory = new CustomerGenreRepository() { ConnectionString = GetConnectionString() };
            var customerGenre = customerGenreRepostory.CustomerGenre();

            //customerRepository.Add(new Customer(60, "Mike", "Test", "Finland", "33000", "020202", "email@com.com"));

            //customerRepository.Update(new Customer(60, "Ada", "Nimi", "Finland", "33000", "020202", "email@com.com"));

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

            Console.WriteLine();
            Console.WriteLine();

            foreach (var customer in getCustomerListWithLimitAndOffset)
            {
                Console.Write(customer.id + ": \t ");
                Console.Write(customer.firstname + "\t");
                Console.Write(customer.lastname + "\t");
                Console.Write(customer.country + "\t");
                Console.Write(customer.postalcode + " \t");
                Console.Write(customer.phone + " \t");
                Console.WriteLine(customer.email);
            }
            Console.WriteLine();
            Console.WriteLine();

            foreach (var country in customerCountByCountry)
            {
                Console.Write(country.country + ":");
                Console.Write(country.id + "\n");
                
            }

            Console.WriteLine();
            Console.WriteLine();

            foreach (var country in customerSpending)
            {
                Console.Write(country.id + ":");
                Console.Write(country.total+ "\n");
            }


            Console.WriteLine();
            Console.WriteLine();

            foreach (var country in customerGenre)
            {
                Console.Write(country.id + ":");
                Console.Write(country.genre + "\n");

            }

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