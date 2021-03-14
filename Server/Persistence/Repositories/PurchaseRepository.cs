using Server.Domains.Models;
using Server.Domains.Repositories;
using Server.Persistence.Contexts;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Server.Persistence.Repositories
{
    public class PurchaseRepository : BaseRepository, IPurchaseRepository
    {
        public PurchaseRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Purchase>> ListAllAsync() => await _context.Purchases.ToListAsync();
        public async Task AddAsync(Purchase purchase) => await _context.Purchases.AddAsync(purchase);

        public async Task<Purchase> FindByIdAsync(int id) => await _context.Purchases.FindAsync(id);

        public void Update(Purchase purchase) => _context.Purchases.Update(purchase);

        public void Remove(Purchase purchase) => _context.Purchases.Remove(purchase);
    }
}
