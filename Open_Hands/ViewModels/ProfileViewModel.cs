using System;
using Open_Hands.Persistence;
using Open_Hands.ViewModels;
using SQLite;
using Xamarin.Forms;

namespace Open_Hands.Views
{
    public class ProfileViewModel : BaseViewModel
    {
        private SQLiteAsyncConnection _connection;
        public IUserDetails _userDetails;

        private string emailLogin;
        public string EmailLogin { get { return emailLogin; } set { SetProperty(ref emailLogin, value); } }
        public ProfileViewModel()
        {
            MessagingCenter.Subscribe<LoginViewModel, string>(this, "Hi", (sender, arg) =>
            {
                EmailLogin = arg;
                DisplayUser(EmailLogin);
            });
        }

        public void DisplayUser (string emailLogin)
        {
            
        }
    }
}
