using Open_Hands.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Open_Hands.ViewModels
{
    public interface IUserDetails
    {
        //Create Account
        Task<IEnumerable<UserDetails>> GetUsers();
        Task<int> CreateUser(UserDetails user);
        Task<UserDetails> GetUser(int id);
        Task<int> UpdateUser(UserDetails user);
        Task DeleteUser(UserDetails user);
        Task<bool> VerifyLogin(string EmailLogin, string PasswordLogin);
        Task<UserDetails> GetUserByEmail(string emailLogin);

    }
}
