using CineRealm.ViewModels;

namespace CineRealm
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new HomeViewModel(Navigation);
        }
    }
}
