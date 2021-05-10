using Open_Hands.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Open_Hands.Persistence
{
    public class SignUpDetailsRepository : ISignUpDetails
    {
        private SQLiteAsyncConnection _connection;

        public SignUpDetailsRepository()
        {
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            _connection.CreateTableAsync<SignUpDetails>();
        }
        public async Task<int> CreateSignUp(SignUpDetails signUp)
        {
            var x = await _connection.InsertAsync(signUp);
            return x;
        }

        public async Task DeleteSignUp(SignUpDetails signUp)
        {
            await _connection.DeleteAsync(signUp);
        }

        public async Task<SignUpDetails> GetSignUp(int id)
        {
            return await _connection.FindAsync<SignUpDetails>(id);
        }

        public async Task<IEnumerable<SignUpDetails>> GetSignUpDetails()
        {
            IEnumerable<SignUpDetails> signUps = new List<SignUpDetails>();
            try
            {
                signUps = await _connection.Table<SignUpDetails>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return signUps;
        }

        public async Task UpdateSignUp(SignUpDetails signUp)
        {
            await _connection.UpdateAsync(signUp);
        }
    }
}
