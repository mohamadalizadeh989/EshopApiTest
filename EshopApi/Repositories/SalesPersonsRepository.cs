using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EshopApi.Contracts;
using EshopApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EshopApi.Repositories
{
    public class SalesPersonsRepository : ISalesPersonsRepository
    {
        private EshopApi_DBContext _context;

        public SalesPersonsRepository(EshopApi_DBContext context)
        {
            _context = context;
        }


        public async Task<SalesPersons> Add(SalesPersons salesPersons)
        {
            await _context.SalesPersons.AddAsync(salesPersons);
            await _context.SaveChangesAsync();
            return salesPersons;
        }

        public async Task<SalesPersons> Find(int id)
        {
            return await _context.SalesPersons.Include(c => c.Orders).SingleOrDefaultAsync(c => c.SalesPersonId == id);
        }

        public IEnumerable<SalesPersons> GetAll()
        {
            return _context.SalesPersons.ToList();
        }

        public async Task<bool> IsExists(int id)
        {
            return await _context.SalesPersons.AnyAsync(c => c.SalesPersonId == id);
        }

        public async Task<SalesPersons> Remove(int id)
        {
            var salesPersons = await _context.SalesPersons.SingleAsync(c => c.SalesPersonId == id);
            _context.SalesPersons.Remove(salesPersons);
            await _context.SaveChangesAsync();
            return salesPersons;
        }

        public async Task<SalesPersons> Update(SalesPersons salesPersons)
        {
            _context.Update(salesPersons);
            await _context.SaveChangesAsync();
            return salesPersons;
        }
    }
}
