using Server.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Domains.Repositories
{
  public interface IProductRepository : IBaseRepository<Product>
  {
    Task<IEnumerable<Product>> GetProductsByCompanyId(int companyId);
    Task<IEnumerable<Product>> GetProductsByPurchaseId(int purchaseId);

  }
}
