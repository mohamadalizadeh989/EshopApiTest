using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EshopApi.Contracts;
using EshopApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EshopApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private EshopApi_DBContext _context;

        public ProductRepository(EshopApi_DBContext context)
        {
            _context = context;
        }


        public async Task<Products> Add(Products product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Products> Find(int id)
        {
            return await _context.Products.SingleOrDefaultAsync(c => c.ProductId == id);
        }

        public IEnumerable<Products> GetAll()
        {
            return _context.Products.ToList();
        }

        public async Task<bool> IsExists(int id)
        {
            return await _context.Products.AnyAsync(c => c.ProductId == id);
        }

        public async Task<Products> Remove(int id)
        {
            var product = await _context.Products.SingleAsync(c => c.ProductId == id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Products> Update(Products product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
