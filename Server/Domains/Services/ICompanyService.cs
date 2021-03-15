using Server.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Domains.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> ListAllAsync();
        Task<Company> FindById(int id);
        
    }
}
