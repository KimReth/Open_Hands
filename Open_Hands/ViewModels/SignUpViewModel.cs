using Open_Hands.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Open_Hands.ViewModels
{
    class SignUpViewModel : BaseViewModel
    {
        public Command SignUpNowCommand { get; set; }

        public SignUpViewModel()
        {
            SignUpNowCommand = new Command(OnSignUpNowClicked);
        }

        private async void OnSignUpNowClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }


    }
}
