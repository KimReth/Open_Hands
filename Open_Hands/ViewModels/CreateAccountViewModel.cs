using Open_Hands.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Open_Hands.ViewModels
{
    public class CreateAccountViewModel : BaseViewModel
    {
        public Command ConfirmNewAccountCommand { get; }

        public CreateAccountViewModel()
        {                
            ConfirmNewAccountCommand = new Command(OnCreateConfirmClicked);
        }

        private async void OnCreateConfirmClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
        
    }    
}
