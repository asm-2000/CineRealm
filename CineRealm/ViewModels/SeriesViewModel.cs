using CineRealm.APIServices;
using CineRealm.Models;
using CineRealm.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace CineRealm.ViewModels
{
    public partial class SeriesViewModel: ObservableObject
    {
        private INavigation _navigation;
        private List<Movie>? _allSeries;
        private APIService _apiService;
    
        [ObservableProperty]
        private List<Movie>? _topIMDBSeries;

        [ObservableProperty]
        private List<Movie>? _dramaSeries;

        [ObservableProperty]
        private List<Movie>? _scifiSeries;

        [ObservableProperty]
        private List<Movie>? _horrorSeries;

        [ObservableProperty]
        private List<Movie>? _crimeSeries;

        [ObservableProperty]
        private List<Movie>? _comedySeries;

        [ObservableProperty]
        private List<Movie>? _actionSeries;

        [ObservableProperty]
        private string _isLoading = "true";

        [ObservableProperty]
        private string _hasLoaded = "false";

        [ObservableProperty]
        private string _errorMessage = "";

        private const string _seriesCacheKey = "cachedSeries";

        public SeriesViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _apiService = new APIService();
            _allSeries = new List<Movie>();
            _topIMDBSeries = new List<Movie>();
            _dramaSeries = new List<Movie>();
            _comedySeries = new List<Movie>();
            _scifiSeries = new List<Movie>();
            _horrorSeries = new List<Movie>();
            _crimeSeries = new List<Movie>();
            _actionSeries = new List<Movie>();
            GetAllSeries();
        }

        [RelayCommand]
        public async Task GetAllSeries()
        {
            IsLoading = "true";
            HasLoaded = "false";
            ErrorMessage = string.Empty;
            try
            {
                Debug.WriteLine("called series");
                _allSeries = await _apiService.GetAllSeries();
                if (_allSeries.Count != 0)
                {
                    SeggregateSeriesOnGenre(_allSeries);
                    IsLoading = "false";
                    HasLoaded = "true";
                }
                else
                {
                    ErrorMessage = "Couldn't Fetch Series/Series";
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

        public void SeggregateSeriesOnGenre(List<Movie> allSeries)
        {
            foreach (Movie series in allSeries)
            {
                if (series.Genre.Contains("Drama"))
                {
                    DramaSeries.Add(series);
                }
                if (series.Genre.Contains("Action"))
                {
                    ActionSeries.Add(series);
                }
                if (series.Genre.Contains("Comedy"))
                {
                    ComedySeries.Add(series);
                }
                if (series.Genre.Contains("Sci-Fi") || series.Genre.Contains("Science Fiction"))
                {
                    ScifiSeries.Add(series);
                }
                if (series.Genre.Contains("Crime"))
                {
                    CrimeSeries.Add(series);
                }
                if (series.Genre.Contains("Horror"))
                {
                    HorrorSeries.Add(series);
                }

                if (Convert.ToDouble(series.ImdbRating) >= 8.7 && TopIMDBSeries.Count < 10)
                {
                    TopIMDBSeries.Add(series);
                }
            }
        }

        [RelayCommand]
        public async Task HandleCardTapped(string title)
        {
            Movie? tappedMovie = _allSeries.Find(movie => movie.Title == title);
            await _navigation.PushAsync(new MovieDetailPage(tappedMovie));
        }
    }
}
