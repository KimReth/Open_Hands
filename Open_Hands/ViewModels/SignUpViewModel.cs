using Open_Hands.Models;
using Open_Hands.Persistence;
using Open_Hands.Views;
using System;
using Xamarin.Forms;

namespace Open_Hands.ViewModels
{
    class SignUpViewModel : BaseViewModel
    {

        public ISignUpDetails _signUpDetails;
        public SignUpDetails SignUpDetails { get; set; }
        public Command SignUpNowCommand { get; set; }
        public int Id { get; set; }

        public SignUpViewModel(int eventID)
        {
            _signUpDetails = new SignUpDetailsRepository();
            SignUpNowCommand = new Command(OnSignUpNowClicked);
            this.EventID = eventID;
        }

        private int eventID;
        public int EventID { get { return eventID;} set { SetProperty(ref eventID, value); } }

        private bool isVolunteer;
        public bool IsVolunteer { get { return isVolunteer; } set { SetProperty(ref isVolunteer, value); } }

        private string firstName;
        public string FirstName { get { return firstName; } set { SetProperty(ref firstName, value); } }

        private string lastName;
        public string LastName { get { return lastName; } set { SetProperty(ref lastName, value); } }

        private string phone;
        public string PhoneNum { get { return phone; } set { SetProperty(ref phone, value); } }

        private string email;
        public string Email { get { return email; } set { SetProperty(ref email, value); } }

        private DateTime birthdate;
        public DateTime Birthdate { get { return birthdate; } set { SetProperty(ref birthdate, value); } }

        private string comments;
        public string Comments { get { return comments; } set { SetProperty(ref comments, value); } }


        private async void OnSignUpNowClicked(object obj)
        {
            try
            {
                var x = await _signUpDetails.CreateSignUp(new SignUpDetails
                {
                    Id = this.Id,
                    IdEventDetails = this.EventID,
                    FirstName = this.FirstName,
                    LastName = this.LastName,
                    PhoneNum = this.PhoneNum,
                    Email = this.Email,
                    Birthdate = this.Birthdate,
                    IsVolunteer = this.IsVolunteer,
                    Comments = this.Comments
                });
                if (x==0)
                {
                    await App.Current.MainPage.DisplayAlert("Failure!", "No Entry Can Be Blank", "Oops");
                }
                else if (x==1)
                {
                    await App.Current.MainPage.DisplayAlert("Success!", "Check Your Email For Further Information", "Sweet");
                    await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
                }
                else if (x==2)
                {
                    await App.Current.MainPage.DisplayAlert("Failure!", "That's Not A Valid Email", "My Bad");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
