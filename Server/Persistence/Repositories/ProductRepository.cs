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

    public ProductRepository(AppDbContext context) : base(context) { }

    public async Task AddAsync(Product item)
    {
      await _context.Products.AddAsync(item);
    }

    public async Task<Product> FindByIdAsync(int id)
    {
      return await _context.Products.FindAsync(id);
    }

    public async Task<IEnumerable<Product>> GetProductsByCompanyId(int companyId)
    {
      return await _context.Products.Where(product => product.CompanyId == companyId).ToListAsync();
    }

    public async Task<IEnumerable<Product>> ListAllAsync()
    {
      var products = await _context.Products.ToListAsync();
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
  }
}
