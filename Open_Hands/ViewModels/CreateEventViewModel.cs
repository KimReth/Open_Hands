using Open_Hands.Models;
using Open_Hands.Persistence;
using Open_Hands.Views;
using System;
using Xamarin.Forms;

namespace Open_Hands.ViewModels
{
    public class CreateEventViewModel : BaseViewModel
    {
        public IEventDetails _eventDetails;
        public EventDetails EventDetails { get; set; }
        public Command PublishEventCommand { get; }
        public CreateEventViewModel()
        {
            _eventDetails = new EventDetailsRepository();
            PublishEventCommand = new Command(OnPublishEventClicked);
        }

        public int Id { get; set; }

        private string contactFirstName;
        public string ContactFirstName { get { return contactFirstName; } set { SetProperty(ref contactFirstName, value); } }

        private string contactLastName;
        public string ContactLastName { get { return contactLastName; } set { SetProperty(ref contactLastName, value); } }

        private string eventName;
        public string EventName { get { return eventName; } set { SetProperty(ref eventName, value); } }

        private string street;
        public string Street { get { return street; } set { SetProperty(ref street, value); } }

        private DateTime startingDate;
        public DateTime StartingDate { get { return startingDate; } set { SetProperty(ref startingDate, value); } }

        private TimeSpan startTime;
        public TimeSpan StartTime { get { return startTime; } set { SetProperty(ref startTime, value); } }

        private DateTime endingDate;
        public DateTime EndingDate { get { return endingDate; } set { SetProperty(ref endingDate, value); } }

        private TimeSpan endTime;
        public TimeSpan EndTime { get { return endTime; } set { SetProperty(ref endTime, value); } }

        private string city;
        public string City { get { return city; } set { SetProperty(ref city, value); } }

        private string state;
        public string State { get { return state; } set { SetProperty(ref state, value); } }

        private string zip;
        public string Zip { get { return zip; } set { SetProperty(ref zip, value); } }

        public string FullAddress { get { return string.Format($"{City}, {State}"); } }

        private string contactPhoneNum;
        public string ContactPhoneNum { get { return contactPhoneNum; } set { SetProperty(ref contactPhoneNum, value); } }

        private string description;
        public string Description { get { return description; } set { SetProperty(ref description, value); } }

        private int maxVolunteers;
        public int MaxVolunteers { get { return maxVolunteers; } set { SetProperty(ref maxVolunteers, value); } }

        public async void OnPublishEventClicked()
        {
            try
            {
                var x = await _eventDetails.CreateEvent(new EventDetails
                {
                    Id = this.Id,
                    ContactFirstName = this.ContactFirstName,
                    ContactLastName = this.ContactLastName,
                    ContactPhoneNum = this.ContactPhoneNum,
                    EventName = this.EventName,
                    Street = this.Street,
                    City = this.City,
                    State = this.State,
                    Zip = this.Zip,
                    Description = this.Description,
                    MaxVolunteers = this.MaxVolunteers,
                    StartingDate = this.StartingDate,
                    EndingDate = this.EndingDate,
                    StartTime = this.StartTime,
                    EndTime = this.EndTime
                });
                if (x == 1)
                {
                    await App.Current.MainPage.DisplayAlert("Success!", "Event Created", "Sweet");
                    await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
                }
                else if (x == 0)
                {
                    await App.Current.MainPage.DisplayAlert("Failure!", "No Entry Can Be Blank", "Oops");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}