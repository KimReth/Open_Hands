using Open_Hands.Models;
using Open_Hands.Persistence;
using Open_Hands.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Open_Hands.ViewModels
{
    class SignUpViewModel : BaseViewModel
    {
        
        public ISignUpDetails _signUpDetails;
        public SignUpDetails SignUpDetails { get; set; }
        public Command SignUpNowCommand { get; set; }
        public int Id { get; set; }

        public SignUpViewModel()
        {
            _signUpDetails = new SignUpDetailsRepository();
            SignUpNowCommand = new Command(OnSignUpNowClicked);
        }

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
                await _signUpDetails.CreateSignUp(new SignUpDetails
                {
                    //TODO: set value of event ID once implemented properly
                    Id = this.Id,
                    FirstName = this.FirstName,
                    LastName = this.LastName,
                    PhoneNum = this.PhoneNum,
                    Email = this.Email,
                    Birthdate = this.Birthdate,
                    IsVolunteer = this.IsVolunteer,
                    Comments = this.Comments
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
            }
    }
}
