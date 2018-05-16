using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using NorthwindEntitiesLib;
using NorthwindContextLib;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

namespace NorthwindService.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private static ConcurrentDictionary<string, Customer> _customerCache;

        private Northwind _db;

        public CustomerRepository(Northwind db)
        {
            this._db = db;
            if(_customerCache == null)
            {
                _customerCache = new ConcurrentDictionary<string, Customer>(
                     _db.Customers.ToDictionary(c => c.CustomerID)
                );
            }
        }

        public async Task<Customer> CreateAsync(Customer c)
        {
            c.CustomerID = c.CustomerID.ToUpper();

            EntityEntry<Customer> added = await _db.Customers.AddAsync(c);

            int affected = await _db.SaveChangesAsync();

            if(affected == 1)
            {
                return _customerCache.AddOrUpdate(c.CustomerID, c, UpdateCache);
            }else{
                return null;
            }
        }

        private Customer UpdateCache(string arg1, Customer arg2)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Customer>> RetrieveAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Customer> UpdateAsync(string id, Customer c)
        {
            throw new System.NotImplementedException();
        }
    }
}