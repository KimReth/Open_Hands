using Open_Hands.ViewModels;
using Open_Hands.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Open_Hands
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
