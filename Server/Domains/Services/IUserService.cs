using System.Threading.Tasks;
using Server.Domains.Models;

namespace Server.Domains.Services
{
    public interface IUserService
    {
        Task<User> FirstOrDefaultAsync(string email, string password);
    }
}
