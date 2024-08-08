using CineRealm.APIServices;
using CineRealm.Models;
using CineRealm.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace CineRealm.ViewModels
{
    public partial class HomeViewModel:ObservableObject
    {
        [ObservableProperty]
        private string? _title;

        [ObservableProperty]
        private Movie? _movieDetails;

        [ObservableProperty]
        private string _error = "";

        [ObservableProperty]
        private string _errorVisible = "false";

        [ObservableProperty]
        private string _isSearching = "false";

        private APIService _apiservice = new();
        private INavigation _navigation;

        public HomeViewModel(INavigation navigation)
        {
            _movieDetails = new Movie();
            _navigation = navigation;
        }

        [RelayCommand]
        public async Task GetMovieDetail()
        {
            ErrorVisible = "false";
            IsSearching = "true";
            try
            {
                MovieDetails = await _apiservice.SearchMovie(Title);
                if(MovieDetails.ImdbID != null)
                {
                    ErrorVisible = "false";
                    Error = "";
                    Debug.WriteLine(MovieDetails.Title);
                    await _navigation.PushAsync(new MovieDetailPage(MovieDetails));
                }
                else
                {
                    ErrorVisible = "true";
                    Error = "Movie Not Found !";
                }
                IsSearching = "false";
            }
            catch(Exception ex)
            {
                ErrorVisible = "true";
                Error = ex.Message;
            }    
        }

        [RelayCommand]
        public async Task NavigateToHomePage()
        {
            await _navigation.PushAsync(new MoviesPage());
        }
    }
}
