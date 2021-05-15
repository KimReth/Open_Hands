using MvvmHelpers;
using MvvmHelpers.Commands;
using Open_Hands.Models;
using Open_Hands.Persistence;
using Open_Hands.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Open_Hands.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public Xamarin.Forms.Command CreateEventCommand { get; }

        public Xamarin.Forms.Command EventClickedCommand { get; }
        public IEventDetails _eventDetails;
        public EventDetails EventDetails { get; set; }
        public PostDetailViewModel postDetailViewModel;
        public AsyncCommand RefreshCommand { get; }
        public ObservableRangeCollection<EventDetails> Events { get; set; }

        EventDetails selectedEvent;
        public HomeViewModel()
        {
            postDetailViewModel = new PostDetailViewModel();
            CreateEventCommand = new Xamarin.Forms.Command(OnCreateEventClicked);
            EventClickedCommand = new Xamarin.Forms.Command(OnEventClicked);
            RefreshCommand = new AsyncCommand(Refresh);
            _eventDetails = new EventDetailsRepository();
            Events = new ObservableRangeCollection<EventDetails>();
            DisplayEvents();
        }

        public EventDetails SelectedEvent
        {
            get
            {
                return selectedEvent;
            }
            set
            {
                if (selectedEvent != value)
                {
                    selectedEvent = value;
                }
            }
        }

        public async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(2000);

            IsBusy = false;
        }
        public async void DisplayEvents()
        {
            var events = await _eventDetails.GetEvents();
            Events.AddRange(events);
        }

        public async void OnEventClicked(object obj)
        {
            postDetailViewModel.SelectionInfo(SelectedEvent);
            await Shell.Current.GoToAsync($"//{nameof(PostDetailPage)}");
        }
        private async void OnCreateEventClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(CreateEventPage)}");
        }
    }
}
