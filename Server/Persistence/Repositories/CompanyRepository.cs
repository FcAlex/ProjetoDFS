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
    public class CompanyRepository : BaseRepository, ICompanyRepository
    {
        public CompanyRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Company item) => await _context.Companies.AddAsync(item);

        public async Task<Company> FindByIdAsync(int id) => await _context.Companies.FindAsync(id);

        public async Task<IEnumerable<Company>> ListAllAsync() => await _context.Companies.Include(p => p.Products).ToListAsync();

        public void Remove(Company item) => _context.Companies.Remove(item);

        public void Update(Company item) => _context.Companies.Update(item);
    }
}
