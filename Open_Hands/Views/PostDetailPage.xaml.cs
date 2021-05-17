using Open_Hands.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Open_Hands.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostDetailPage : ContentPage
    {
        public int EventID {get;set;}
        public PostDetailPage(EventDetails eventDetails)
        {
            InitializeComponent();
            this.BindingContext = eventDetails;
            this.EventID = eventDetails.Id;
        }
        public async void OnSignUpClicked(object obj, EventArgs args)
        {
            await Shell.Current.Navigation.PushAsync(new SignUpPage(EventID));
        }
    }
}