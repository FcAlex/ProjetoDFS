using Server.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Domains.Repositories
{
    public interface IPurchaseRepository : IBaseRepository<Purchase>
    {
        Task<IEnumerable<Purchase>> GetPurchaseByUserAsync(int id);
    }
}
