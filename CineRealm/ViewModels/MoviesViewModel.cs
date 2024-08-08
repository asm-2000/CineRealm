using CineRealm.APIServices;
using CineRealm.Models;
using CineRealm.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace CineRealm.ViewModels
{
    public partial class MoviesViewModel: ObservableObject
    {
        private INavigation _navigation;
        private List<Movie>? _allMovies;
        private APIService _apiService;

        [ObservableProperty]
        private List<Movie>? _topIMDBMovies;

        [ObservableProperty]
        private List<Movie>? _dramaMovies;

        [ObservableProperty]
        private List<Movie>? _scifiMovies;

        [ObservableProperty]
        private List<Movie>? _horrorMovies;

        [ObservableProperty]
        private List<Movie>? _crimeMovies;

        [ObservableProperty]
        private List<Movie>? _comedyMovies;

        [ObservableProperty]
        private List<Movie>? _actionMovies;

        [ObservableProperty]
        private string _isLoading = "true";

        [ObservableProperty]
        private string _hasLoaded = "false";

        [ObservableProperty]
        private string _errorMessage = "";

        private const string MoviesCacheKey = "cachedMovies";

        public MoviesViewModel(INavigation navigation) 
        {
            _navigation = navigation;
            _apiService = new APIService();
            _allMovies = new List<Movie>();
            _topIMDBMovies = new List<Movie>();
            _dramaMovies = new List<Movie>();
            _comedyMovies = new List<Movie>();
            _scifiMovies = new List<Movie>();
            _horrorMovies = new List<Movie>();
            _crimeMovies = new List<Movie>();
            _actionMovies = new List<Movie>();
            GetAllMovies();
        }

        [RelayCommand]
        public async Task GetAllMovies()
        {
            IsLoading = "true";
            HasLoaded = "false";
            ErrorMessage = string.Empty;
                try
                {
                    _allMovies = await _apiService.GetAllMovies();
                    if (_allMovies.Count != 0)
                    {
                        SeggregateMoviesOnGenre(_allMovies);
                        IsLoading = "false";
                        HasLoaded = "true";
                    }
                    else
                    {
                        ErrorMessage = "Couldn't Fetch Movies/Series";
                        IsLoading = "false";
                        HasLoaded = "false";
                    }
                }
                catch (Exception ex)
                {
                    IsLoading = "false";
                    HasLoaded = "true";
                    ErrorMessage = ex.Message;
                }
        }

        public void SeggregateMoviesOnGenre(List<Movie> allMovies)
        {
            foreach(Movie movie in allMovies)
            {
                if(movie.Genre.Contains("Drama"))
                {
                    DramaMovies.Add(movie);
                }
                if (movie.Genre.Contains("Action"))
                {
                    ActionMovies.Add(movie);
                }
                if (movie.Genre.Contains("Comedy"))
                {
                    ComedyMovies.Add(movie);
                }
                if (movie.Genre.Contains("Sci-Fi") || movie.Genre.Contains("Science Fiction"))
                {
                    ScifiMovies.Add(movie);
                }
                if (movie.Genre.Contains("Crime"))
                {
                    CrimeMovies.Add(movie);
                }
                if (movie.Genre.Contains("Horror"))
                {
                    HorrorMovies.Add(movie);
                }

                if(Convert.ToDouble(movie.ImdbRating) >= 8.7 && TopIMDBMovies.Count < 10)
                {
                    TopIMDBMovies.Add(movie);
                }
            }
        }

        [RelayCommand]
        public async Task HandleCardTapped(string title)
        {
            Movie? tappedMovie = _allMovies.Find(movie => movie.Title == title);
            await _navigation.PushAsync(new MovieDetailPage(tappedMovie));
        }
    }
}
