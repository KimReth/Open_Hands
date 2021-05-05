using Open_Hands.Persistence;
using Open_Hands.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Open_Hands.Views
{
    public class ProfileViewModel : BaseViewModel
    {
        private SQLiteAsyncConnection _connection;
        public IUserDetails _userDetails;
        public ProfileViewModel()
        {
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            _userDetails = new UserDetailsRepository();
        }
    }
}
