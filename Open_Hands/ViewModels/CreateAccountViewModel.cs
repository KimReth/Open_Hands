using Open_Hands.Models;
using Open_Hands.Views;
using Open_Hands.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;


namespace Open_Hands.ViewModels
{
    public class CreateAccountViewModel : BaseViewModel
    {
        public IUserDetails _userDetails;
        public UserDetails UserDetails { get; set; }
        public Command ConfirmNewAccountCommand { get; }
        public int Id { get; set; }



        public CreateAccountViewModel()
        {
            _userDetails = new UserDetailsRepository();
            ConfirmNewAccountCommand = new Command(OnCreateConfirmClicked);
        }


       
        private string firstName;
        public string FirstName {  get { return firstName; } set {SetProperty(ref firstName, value); } }

        private string lastName;
        public string LastName { get { return lastName; } set { SetProperty(ref lastName, value); } }

        private string phone;
        public string PhoneNum { get { return phone; } set { SetProperty(ref phone, value); } } 

        private string email;
        public string Email { get { return email; } set { SetProperty(ref email, value); } }

        private DateTime birthdate;
        public DateTime Birthdate { get { return birthdate; } set { SetProperty(ref birthdate, value); } } 

        private string role;
        public string Role { get { return role; } set { SetProperty(ref role, value); } }

        private string password;
        public string Password { get { return password; } set { SetProperty(ref password, value); } }


        public async void OnCreateConfirmClicked()
        {
            try
            {
                await _userDetails.CreateUser(new UserDetails
                {
                    Id = this.Id,
                    FirstName = this.FirstName,
                    LastName = this.LastName,
                    PhoneNum = this.PhoneNum,
                    Email = this.Email,
                    Birthdate = this.Birthdate,
                    Role = this.Role,
                    Password = this.Password
                });
            }
            catch(Exception ex)
            {
                throw ex;
            }
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }    
}
