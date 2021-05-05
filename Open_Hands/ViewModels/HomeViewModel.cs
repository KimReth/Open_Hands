using Open_Hands.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Open_Hands.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public Command CreateEventCommand { get; }

        public HomeViewModel()
        {
            CreateEventCommand = new Command(OnCreateEventClicked);
        }

        private async void OnCreateEventClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(CreateEventPage)}");
        }
    }
}
