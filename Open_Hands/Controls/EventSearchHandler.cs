using Open_Hands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;


namespace Open_Hands
{
    public class EventSearchHandler : SearchHandler
    {
        public IList<EventDetails> Events { get; set; }
        public Type SelectedItemNavigationTarget { get; set; }

        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                ItemsSource = Events.Where(events => events.City.ToLower().Contains(newValue.ToLower()) || events.State.ToLower().Contains(newValue.ToLower())).ToList<EventDetails>();
            }
        }

        //protected override async void OnItemSelected(object item)
        //{
        //    base.OnItemSelected(item);


        //    ShellNavigationState state = (App.Current.MainPage as Shell).CurrentState;
        //    // The following route works because route names are unique in this application.
        //    await Shell.Current.GoToAsync($"{GetNavigationTarget()}?name={((EventDetails)item).EventName}");
        //}

        //string GetNavigationTarget()
        //{
        //    return (Shell.Current as AppShell).Routes.FirstOrDefault(route => route.Value.Equals(SelectedItemNavigationTarget)).Key;
        //}
    }
}
