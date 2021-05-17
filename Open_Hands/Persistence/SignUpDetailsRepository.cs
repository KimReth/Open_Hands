using Open_Hands.Models;
using SQLite;
using System;
using System.Collections.Generic;
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
            if (signUp.FirstName == null || signUp.LastName == null || signUp.Email == null || signUp.PhoneNum == null)
            {
                var x = 0;
                return x;
            }
            else if (!signUp.Email.Contains("@") || !signUp.Email.Contains("."))
            {
                var x = 2;
                return x;
            }
            else
            {
                var x = await _connection.InsertAsync(signUp);
                return x;
            }
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
