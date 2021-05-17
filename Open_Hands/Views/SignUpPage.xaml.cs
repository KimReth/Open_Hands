using Open_Hands.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Open_Hands.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage(int eventID)
        {
            InitializeComponent();
            BindingContext = new SignUpViewModel(eventID);
        }
        public void OnVolunteerRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            //TO DO: Handle which case is chosen, turn all other entries on if not volunteer
        }
    }
}