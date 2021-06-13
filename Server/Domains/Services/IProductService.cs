using Server.Communication;
using Server.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Domains.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> ListAllAsync();
        Task<Product> FindById(int id);

        Task<IEnumerable<Product>> GetProductsByCompanyId(int companyId);
        Task<Response<Product>> SaveAsync(Product product);
        Task<Response<Product>> UpdateAsync(int id, Product product);
        Task<Response<Product>> DeleteAsync(int id);
    }
}
