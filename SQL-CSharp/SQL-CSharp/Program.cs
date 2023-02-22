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

            customerRepository.Add(new Customer(60, "Mike", "Test", "Finland", "33000", "020202", "email@com.com"));
            customerRepository.Update(new Customer(60, "Ada", "Nimi", "Finland", "33000", "020202", "email@com.com"));

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
            //Console.WriteLine("\n" + getCustomerListWithLimitAndOffset.id + ":" + getCustomerListWithLimitAndOffset.firstname + "\t" + getCustomerListWithLimitAndOffset.lastname + "\t" + getCustomerListWithLimitAndOffset.country + "\t" + getCustomerListWithLimitAndOffset.postalcode + "\t" + getCustomerListWithLimitAndOffset.phone + "\t" + getCustomerListWithLimitAndOffset.email);

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