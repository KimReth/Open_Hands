using Open_Hands.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Open_Hands.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostDetailPage : ContentPage
    {
        public PostDetailPage()
        {
            InitializeComponent();
            BindingContext = new PostDetailViewModel();
        }
        //public PostDetail(EventDetails eventDetails)
        //{
        //    InitializeComponent();
        //    postDetailViewModel = new PostDetailViewModel(eventDetails);
        //    this.BindingContext = postDetailViewModel;
        //}
    }
}