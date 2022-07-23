using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EshopApi.Contracts;
using EshopApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace EshopApi.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private EshopApi_DBContext _context;
        private IMemoryCache _cache;

        public CustomerRepository(EshopApi_DBContext context,IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customer.ToList();
        }

        public async Task<Customer> Add(Customer customer)
        {
            await _context.Customer.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> Find(int id)
        {

            return await _context.Customer.Include(c => c.Orders).SingleOrDefaultAsync(c => c.CustomerId == id);
        }

        public async Task<Customer> Update(Customer customer)
        {
            _context.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> Remove(int id)
        {
            var customer = await _context.Customer.SingleAsync(c => c.CustomerId == id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<bool> IsExists(int id)
        {
            return await _context.Customer.AnyAsync(c => c.CustomerId == id);
        }

        public async Task<int> CountCustomer()
        {
            return await _context.Customer.CountAsync();
        }
    }
}
