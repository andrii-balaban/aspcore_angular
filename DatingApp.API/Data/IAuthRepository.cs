using System.Threading.Tasks;
using DatingApp.API.Models;

namespace DatingApp.API.Data
{
    public interface IAuthRepository
    {
        Task<User> RegisterAsync(User user, string password);

        Task<User> LoginAsync(string userName, string password);

        Task<bool> UserExistsAync(string userName);        
    }
}