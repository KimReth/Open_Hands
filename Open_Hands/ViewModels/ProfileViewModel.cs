using System;
using MvvmHelpers;
using Open_Hands.Models;
using Open_Hands.Persistence;
using Open_Hands.ViewModels;
using SQLite;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Open_Hands.Views
{
    public class ProfileViewModel : ViewModels.BaseViewModel
    {
        public IUserDetails _userDetails;
        public Command EditProfileCommand { get; }
        public Command SaveProfileCommand { get; }

        public ProfileViewModel()
        {
            _userDetails = new UserDetailsRepository();
            EditProfileCommand = new Command(OnEditProfileClicked);
            SaveProfileCommand = new Command(OnSaveClicked);
            VisibilityStart();
            DisplayUser();
        }
        public async void DisplayUser()
        {
            var emailLogin = Preferences.Get("UserEmail", "");
            var user = await _userDetails.GetUserByEmail(emailLogin);

            FirstName = user.FirstName;
            LastName = user.LastName;
            PhoneNum = user.PhoneNum;
            Email = user.Email;
            Birthdate = user.Birthdate;
            Role = user.Role;
            Password = user.Password;
        }
        public void VisibilityStart()
        {
            EditVisible = true;
            //TODO: Set initial label visibilities to true
        }
        public void OnEditProfileClicked()
        {
            FirstNameVisible = true;
            LastNameVisible = true;
            EmailVisible = true;
            PhoneVisible = true;
            RoleVisible = true;
            BirthdateVisible = true;
            SaveVisible = true;
            PasswordVisible = true;
            ConfirmVisible = true;

            EditVisible = false;
            //TODO: Set visibilities to false of other initial labels and add their properties
        }
        public void OnSaveClicked()
        {
            //TODO: save new input to datebase. Link repo=>update
        }

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

        private string role;
        public string Role { get { return role; } set { SetProperty(ref role, value); } }

        private string password;
        public string Password { get { return password; } set { SetProperty(ref password, value); } }

        private bool editVisible;
        public bool EditVisible { get { return editVisible; } set { SetProperty(ref editVisible, value); } }

        private bool firstNameVisible;
        public bool FirstNameVisible { get { return firstNameVisible; } set { SetProperty(ref firstNameVisible, value); } }

        private bool lastNameVisible;
        public bool LastNameVisible { get { return lastNameVisible; } set { SetProperty(ref lastNameVisible, value); } }

        private bool emailVisible;
        public bool EmailVisible { get { return emailVisible; } set { SetProperty(ref emailVisible, value); } }

        private bool phoneVisible;
        public bool PhoneVisible { get { return phoneVisible; } set { SetProperty(ref phoneVisible, value); } }

        private bool roleVisible;
        public bool RoleVisible { get { return roleVisible; } set { SetProperty(ref roleVisible, value); } }

        private bool birthdateVisible;
        public bool BirthdateVisible { get { return birthdateVisible; } set { SetProperty(ref birthdateVisible, value); } }

        private bool passVisible;
        public bool PasswordVisible { get { return passVisible; } set { SetProperty(ref passVisible, value); } }

        private bool confirmVisible;
        public bool ConfirmVisible { get { return confirmVisible; } set { SetProperty(ref confirmVisible, value); } }

        private bool saveVisible;
        public bool SaveVisible { get { return saveVisible; } set { SetProperty(ref saveVisible, value); } }
    }
}
