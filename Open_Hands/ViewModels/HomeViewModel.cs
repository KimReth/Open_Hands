using MvvmHelpers;
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
        public ObservableRangeCollection<EventDetails> Events { get; set; }
        public HomeViewModel()
        {
            CreateEventCommand = new Command(OnCreateEventClicked);
            _eventDetails = new EventDetailsRepository();
            Events = new ObservableRangeCollection<EventDetails>();
            DisplayEvents();
        }

        public async void DisplayEvents()
        {
            var events = await _eventDetails.GetEvents();
            Events.AddRange(events);
        }
        private async void OnCreateEventClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(CreateEventPage)}");
        }
    }
}
