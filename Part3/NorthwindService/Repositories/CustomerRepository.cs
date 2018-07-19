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

        public CustomerRepository()
        {
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

        private Customer UpdateCache(string id, Customer c)
        {
            Customer old;
            if(_customerCache.TryGetValue(id, out old))
            {
                if(_customerCache.TryUpdate(id, c, old)){
                    return c;
                }
            }
            return null;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await Task.Run(() => 
            {
                Customer c = _db.Customers.Find(id.ToUpper());
                _db.Customers.Remove(c);
                int affected = _db.SaveChanges();

                if(affected == 1){
                    return Task.Run(() => _customerCache.TryRemove(id, out c));
                }else{
                    return null;
                }
            });
        }

        public async Task<IEnumerable<Customer>> RetrieveAllAsync()
        {
            return await Task.Run<IEnumerable<Customer>>(() 
                => _customerCache.Values);
        }

        public async Task<Customer> GetCustomerAsync(string id) => await this._db.Customers
                                                                        .Where(c => c.CustomerID == id.ToUpper())
                                                                        .FirstOrDefaultAsync();

        public async Task<Customer> UpdateAsync(string id, Customer c)
        {
            return await Task.Run(() => 
            {
                c.CustomerID  = c.CustomerID.ToUpper();
                _db.Customers.Update(c);
                

                //check if the changes affected anything
                if(_db.SaveChanges() == 1)
                {
                    return Task.Run(() => UpdateCache(id, c));
                }
                return null;
            });
        }

        public async Task<bool> CheckIfUserExist(string id)
        {
            if((await this.GetCustomerAsync(id)) == null){
                return false;
            }else{  
                return true;
            }
        }
    }
}