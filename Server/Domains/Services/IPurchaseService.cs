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
        Task<Response<Purchase>> SaveAsync(Purchase purchase);
        Task<Response<Purchase>> UpdateAsync(int id, Purchase purchase);
        Task<Response<Purchase>> DeleteAsync(int id);
    }
}
