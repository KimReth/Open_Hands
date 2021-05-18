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

            Id = user.Id;
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
            NameVisible = true;
            OrgEmailVisible = true;
            OrgPhoneVisible = true;
            OrgBirthVisible = true;
            OrgRoleVisible = true;
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
            NameVisible = false;
            OrgEmailVisible = false;
            OrgPhoneVisible = false;
            OrgBirthVisible = false;
            OrgRoleVisible = false;
        }
        public async void OnSaveClicked()
        {
            if (Password != ConfirmPass)
            {
                await App.Current.MainPage.DisplayAlert("Failure!", "Passwords Do Not Match", "I'll Try Again");
            }
            else
            {
                try
                {
                    var x = await _userDetails.UpdateUser(new UserDetails
                    {
                        Id = Id,
                        FirstName = FirstName,
                        LastName = LastName,
                        PhoneNum = PhoneNum,
                        Email = Email,
                        Birthdate = Birthdate,
                        Role = Role,
                        Password = Password
                    });

                    if (x == 1)
                    {
                        await App.Current.MainPage.DisplayAlert("Success!", "Profile Updated", "Sweet");

                        EditVisible = true;
                        NameVisible = true;
                        OrgEmailVisible = true;
                        OrgPhoneVisible = true;
                        OrgBirthVisible = true;
                        OrgRoleVisible = true;
                        FirstNameVisible = false;
                        LastNameVisible = false;
                        EmailVisible = false;
                        PhoneVisible = false;
                        RoleVisible = false;
                        BirthdateVisible = false;
                        SaveVisible = false;
                        PasswordVisible = false;
                        ConfirmVisible = false;
                    }
                    else if (x == 0)
                    {
                        await App.Current.MainPage.DisplayAlert("Failure!", "No Entry Can Be Blank", "Oops");
                    }
                    else if (x == 2)
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

        public int Id { get; set; }

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

        private string confirmPass;
        public string ConfirmPass { get { return confirmPass; } set { SetProperty(ref confirmPass, value); } }

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

        private bool nameVisible;
        public bool NameVisible { get { return nameVisible; } set { SetProperty(ref nameVisible, value); } }

        private bool orgEmailVisible;
        public bool OrgEmailVisible { get { return orgEmailVisible; } set { SetProperty(ref orgEmailVisible, value); } }

        private bool orgPhoneVisible;
        public bool OrgPhoneVisible { get { return orgPhoneVisible; } set { SetProperty(ref orgPhoneVisible, value); } }

        private bool orgBirthVisible;
        public bool OrgBirthVisible { get { return orgBirthVisible; } set { SetProperty(ref orgBirthVisible, value); } }

        private bool orgRoleVisible;
        public bool OrgRoleVisible { get { return orgRoleVisible; } set { SetProperty(ref orgRoleVisible, value); } }

        private bool saveVisible;
        public bool SaveVisible { get { return saveVisible; } set { SetProperty(ref saveVisible, value); } }
    }
}
