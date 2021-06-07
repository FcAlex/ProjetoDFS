using Server.Domains.Models;
using Server.Domains.Repositories;
using Server.Persistence.Contexts;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

namespace Server.Persistence.Repositories
{
    public class PurchaseRepository : BaseRepository, IPurchaseRepository
    {
        public PurchaseRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Purchase>> ListAllAsync()
        {
            var purchases = await _context.Purchases.ToListAsync();
            purchases.ForEach(purchase => AddUserAndProduct(purchase));
            return purchases;
        }

        public async Task AddAsync(Purchase purchase)
        {
            AddUserAndProduct(purchase);
            await _context.Purchases.AddAsync(purchase);
        }

        public async Task<Purchase> FindByIdAsync(int id)
        {
            var purchase = await _context.Purchases.FindAsync(id);
            AddUserAndProduct(purchase);
            return purchase;
        }

        public void Update(Purchase purchase) => _context.Purchases.Update(purchase);

        public void Remove(Purchase purchase) => _context.Purchases.Remove(purchase);

        private async void AddUserAndProduct(Purchase purchase)
        {
            purchase.User = await _context.Users.FindAsync(purchase.UserId);
            purchase.Product = await _context.Products.FindAsync(purchase.ProductId);
        }

        public async Task<IEnumerable<Purchase>> GetPurchaseByUserAsync(int id) {
            var purchase =  await _context.Purchases
                .FromSqlInterpolated($"SELECT * FROM Purchases WHERE UserId = {id}")
                .ToListAsync();

            return purchase;
        }
    }
}
