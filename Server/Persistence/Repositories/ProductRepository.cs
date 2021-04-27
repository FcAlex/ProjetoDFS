using Microsoft.EntityFrameworkCore;
using Server.Domains.Models;
using Server.Domains.Repositories;
using Server.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Persistence.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {

        ProductRepository (AppDbContext context) : base(context) { }

        public async Task AddAsync(Product item)
        {
            await _context.Products.AddAsync(item);
        }

        public async Task<Product> FindByIdAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            AddCompany(product);
            return product;
        }

        public async Task<IEnumerable<Product>> ListAllAsync()
        {
            var products = await _context.Products.ToListAsync();
            products.ForEach(product => AddCompany(product));

            return products;
        }

        public void Remove(Product item)
        {
            _context.Products.Remove(item);
        }

        public void Update(Product item)
        {
            _context.Products.Update(item);
        }

        private async void AddCompany(Product product)
        {
            product.Company = await _context.Companies.FindAsync(product.CompanyId);
        }
    }
}
