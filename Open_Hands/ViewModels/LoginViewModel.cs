using Open_Hands.Views;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Open_Hands.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Command NewAccountCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            NewAccountCommand = new Command(OnCreateClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }

        private async void OnCreateClicked(object obj)
        {       
            await Shell.Current.GoToAsync($"//{nameof(CreateAccountPage)}");
        }
    }
}
