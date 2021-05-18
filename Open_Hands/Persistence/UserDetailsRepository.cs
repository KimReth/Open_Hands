using Open_Hands.Models;
using Open_Hands.ViewModels;
using SQLite;
using System.Collections.Generic;
using System.Linq;
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
            if (user.FirstName == null || user.LastName == null || user.Email == null || user.Password == null || user.PhoneNum == null)
            {
                var x = 0;
                return x;
            }
            else if (!user.Email.Contains("@") || !user.Email.Contains("."))
            {
                var x = 2;
                return x;
            }
            else
            {
                var x = await _connection.InsertAsync(user);
                return x;
            }
        }

        public async Task<int> UpdateUser(UserDetails user)
        {
            if (user.FirstName == null || user.LastName == null ||  user.Password == null || user.PhoneNum == null)
            {
                var x = 0;
                return x;
            }
            else if (!user.Email.Contains("@") || !user.Email.Contains("."))
            {
                var x = 2;
                return x;
            }
            else
            {
                var x = await _connection.UpdateAsync(user);
                return x;
            }
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
            var loginQuery = await _connection.Table<UserDetails>().Where(u => u.Email == EmailLogin && u.Password == PasswordLogin).ToListAsync();

            if (loginQuery.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<UserDetails> GetUserByEmail(string emailLogin)
        {
            var user = await _connection.Table<UserDetails>().Where(u => u.Email == emailLogin).FirstOrDefaultAsync();
            return user;
        }

    }
}
