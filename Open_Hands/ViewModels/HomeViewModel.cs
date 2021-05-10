using Open_Hands.Models;
using Open_Hands.Persistence;
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
        public IEventDetails _eventDetails;
        public EventDetails EventDetails { get; set; }
        public IEnumerable<EventDetails> Events { get; set; }
        public HomeViewModel()
        {
            CreateEventCommand = new Command(OnCreateEventClicked);
            _eventDetails = new EventDetailsRepository();
            var Events = _eventDetails.GetEvents();
        }

        private async void OnCreateEventClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(CreateEventPage)}");
        }
    }
}
