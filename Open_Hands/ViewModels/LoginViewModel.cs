using Open_Hands.Persistence;
using Open_Hands.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Open_Hands.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public IUserDetails _userDetails;
        public Command NewAccountCommand { get; }
        public Command LoginCommand { get; }  
        //public ProfilePage profilePage { get; }
        public string EmailLogin { get; set; }
        public string PasswordLogin { get; set; }
        
        public LoginViewModel()
        {
            NewAccountCommand = new Command(OnCreateClicked);
            LoginCommand = new Command(OnLoginClicked);
            _userDetails = new UserDetailsRepository();

        }

        private async void OnLoginClicked(object obj)
        {
            Preferences.Set("UserEmail", EmailLogin);
            bool success = await _userDetails.VerifyLogin(EmailLogin, PasswordLogin);
            if (success)
            {
                await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Failure", "Username And Password Does Not Exist", "Try Again");
            }
        }

        private async void OnCreateClicked(object obj)
        {
            await Shell.Current.Navigation.PushAsync(new CreateAccountPage());
        }

    }
}
