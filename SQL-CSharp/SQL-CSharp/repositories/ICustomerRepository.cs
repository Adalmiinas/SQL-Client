using SQL_CSharp.models;

namespace SQL_CSharp.repositories
{
    public interface ICustomerRepository: ICrudRepository<Customer, int>
    {
        string GetCustomerById(int customerDd);
    }
}
