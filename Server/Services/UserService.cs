using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Domains.Models;
using Server.Domains.Services;
using Server.Domains.Repositories;

namespace Server.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> FirstOrDefaultAsync(string email, string password)
        {
            return await _userRepository.FirstOrDefaultAsync(email, password);
        }
    }
}
