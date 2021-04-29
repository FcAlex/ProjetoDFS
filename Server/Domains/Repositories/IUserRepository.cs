using Server.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Domains.Repositories
{
    public interface IUserRepository
    {
        Task<User> FirstOrDefaultAsync(string email, string password);
    }
}
