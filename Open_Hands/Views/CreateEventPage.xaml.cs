using Open_Hands.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Open_Hands.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateEventPage : ContentPage
    {
        public CreateEventPage()
        {
            InitializeComponent();
            BindingContext = new CreateEventViewModel();
        }
    }
}