using CineRealm.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CineRealm.ViewModels
{
    public partial class MovieDetailViewModel:ObservableObject
    {
        private INavigation _navigation;

        [ObservableProperty]
        private string _maxTextLine = "6";

        [ObservableProperty]
        private Movie _movieDetail;

        public MovieDetailViewModel(INavigation navigation, Movie movieDetail) 
        {
            _navigation = navigation;
            _movieDetail = movieDetail;
        }

        [RelayCommand]
        public void ShowMorePlotText()
        {
            MaxTextLine = "25";
        }
    }
}
