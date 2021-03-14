using Server.Domains.Models;
using Server.Domains.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Domains.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ListAllAsync();
        Task<User> FindByIdAsync(int id);
        Task<UserResponse> SaveAsync(User user);
        Task<UserResponse> UpdateAsync(int id, User user);
        Task<UserResponse> DeleteAsync(int id);
    }
}
