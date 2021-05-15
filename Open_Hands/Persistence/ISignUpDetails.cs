using Open_Hands.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Open_Hands.Persistence
{
    public interface ISignUpDetails
    {
        Task<IEnumerable<SignUpDetails>> GetSignUpDetails();
        Task<int> CreateSignUp(SignUpDetails signUp);
        Task<SignUpDetails> GetSignUp(int id);
        Task UpdateSignUp(SignUpDetails signUp);
        Task DeleteSignUp(SignUpDetails signUp);
    }
}
