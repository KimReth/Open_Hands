using Open_Hands.Models;
using Open_Hands.Persistence;
using Open_Hands.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Open_Hands.Persistence
{
    public class UserDetailsRepository : IUserDetails
    {
        private SQLiteAsyncConnection _connection;

        public UserDetailsRepository()
        {
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            _connection.CreateTableAsync<UserDetails>();
        }

        public async Task DeleteUser(UserDetails user)
        {
            await _connection.DeleteAsync(user);
        }

        public async Task<int> CreateUser(UserDetails user)
        {
            var x = await _connection.InsertAsync(user);
            return x;

        }

        public async Task UpdateUser(UserDetails user)
        {
            await _connection.UpdateAsync(user);
        }

        public async Task<UserDetails> GetUser(int id)
        {
            return await _connection.FindAsync<UserDetails>(id);
        }

        public async Task<IEnumerable<UserDetails>> GetUsers()
        {
            var y = await _connection.Table<UserDetails>().ToListAsync();
            return y;
        }

        public async Task<bool> VerifyLogin(string EmailLogin, string PasswordLogin)
        {
            //find user for email, handle not existing, compare password entered if exists
            var loginQuery = await _connection.Table<UserDetails>().Where(u => u.Email == EmailLogin && u.Password == PasswordLogin).FirstOrDefaultAsync();

            if (loginQuery != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
