using CineRealm.Models;
using System.Diagnostics;
using System.Text.Json;

namespace CineRealm.APIServices
{
    public class APIService
    {
        private HttpClient _httpClient;

        private List<Movie> _allMovies = new();

        private List<Movie> _allSeries = new();

        public APIService()
        {
            _httpClient = new HttpClient();
        } 

        public async Task<Movie> SearchMovie(string title)
        {
            Movie? movieDetails = new();
            Uri uri = new("http://www.omdbapi.com/?t="+title+"&plot=full"+"&apikey=b7b769a");
            try
            {
                var response = await _httpClient.GetAsync(uri);
                if(response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    movieDetails = JsonSerializer.Deserialize<Movie>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return movieDetails;
        }

        public async Task<List<Movie>> GetAllMovies()
        { 
            Movie? movie = new();
            List<Movie>? movies = new();
            try
            {
                foreach (string movieTitle in Constants.MovieTitles.MovieTitlesList)
                {
                    Uri uri = new("http://www.omdbapi.com/?t=" + movieTitle + "&plot=full&type=movie" + "&apikey=b7b769a");
                    var response = await _httpClient.GetAsync(uri);
                    if(response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        movie =  JsonSerializer.Deserialize<Movie>(responseBody,new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        movies.Add(movie);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }
            return movies;
        }

        public async Task<List<Movie>> GetAllSeries()
        {
            Movie? series = new();
            List<Movie>? seriesList = new();
            try
            {
                foreach (string seriesTitle in Constants.MovieTitles.TVSeriesTitlesList)
                {
                    Debug.WriteLine($"{seriesTitle}");
                    Uri uri = new("http://www.omdbapi.com/?t=" + seriesTitle + "&plot=full&type=series" + "&apikey=b7b769a");
                    var response = await _httpClient.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        series = JsonSerializer.Deserialize<Movie>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        seriesList.Add(series);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }
            return seriesList;
        }
    }
}
