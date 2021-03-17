using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Domains.Models;
using Server.Domains.Repositories;
using Server.Persistence.Contexts;

namespace Server.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }

        public async Task<User> FirstOrDefaultAsync(string email, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Email == email && user.Password == password);
        }
    }
}
