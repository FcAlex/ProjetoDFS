using Server.Communication;
using Server.Domains.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Domains.Services
{
    public interface IPurchaseService
    {
        Task<IEnumerable<Purchase>> ListAllAsync();
        Task<Purchase> FindByIdAsync(int id);
        Task<PurchaseResponse> SaveAsync(Purchase purchase);
        Task<PurchaseResponse> UpdateAsync(int id, Purchase purchase);
        Task<PurchaseResponse> DeleteAsync(int id);
    }
}
