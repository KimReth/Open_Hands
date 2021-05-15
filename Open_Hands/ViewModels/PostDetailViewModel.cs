using Open_Hands.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Open_Hands.ViewModels
{
    public class PostDetailViewModel : BaseViewModel
    {
        private EventDetails _eventDetails;
        public EventDetails EventDetails
        {
            get => _eventDetails;
            set
            {
                SetProperty(ref _eventDetails, value);
            }
        }

        public string EventName { get; set; }
        public PostDetailViewModel()
        {
            //this.EventDetails = eventDetails;
        }

        public void SelectionInfo(EventDetails eventDetails)
        {
            this.EventDetails = eventDetails;
            this.EventDetails.EventName = EventName;
        }
    }
}
