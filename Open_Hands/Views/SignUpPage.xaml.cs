using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Open_Hands.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }
        public void OnVolunteerRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            //TO DO: Handle which case is chosen, turn all other entries on if not volunteer
        }
    }
}