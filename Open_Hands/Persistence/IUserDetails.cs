using Open_Hands.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Open_Hands.ViewModels
{
    public interface IUserDetails
    {
        //Create Account
        Task<IEnumerable<UserDetails>> GetUsers();
        Task<int> CreateUser(UserDetails user);
        Task<UserDetails> GetUser(int id);
        Task UpdateUser(UserDetails user);
        Task DeleteUser(UserDetails user);
        Task<bool> VerifyLogin(string EmailLogin, string PasswordLogin);

    }
}
