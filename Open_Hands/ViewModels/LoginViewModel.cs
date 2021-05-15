using Open_Hands.Persistence;
using Open_Hands.Views;
using Xamarin.Forms;

namespace Open_Hands.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public IUserDetails _userDetails;
        public Command NewAccountCommand { get; }
        public Command LoginCommand { get; }
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
            bool success = await _userDetails.VerifyLogin(EmailLogin, PasswordLogin);
            if (success)
            {
                await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
            }
            else
            {
                //TODO: Display failure message
            }
        }

        private async void OnCreateClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(CreateAccountPage)}");
        }

    }
}
