using NorthwindEntitiesLib;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NorthwindService.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> CreateAsync(Customer c);

        Task<IEnumerable<Customer>> RetrieveAllAsync();

        Task<Customer> GetCustomerAsync(string id);

        Task<Customer> UpdateAsync(string id, Customer c);

        Task<bool> DeleteAsync(string id);

        Task<bool> CheckIfUserExist(string id);
    }
}