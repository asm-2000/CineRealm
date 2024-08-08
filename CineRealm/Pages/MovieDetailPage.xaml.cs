using CineRealm.Models;
using CineRealm.ViewModels;

namespace CineRealm.Pages;

public partial class MovieDetailPage : ContentPage
{
	private INavigation _navigation { get; set; }
	public MovieDetailPage(Movie movieDetail)
	{
		InitializeComponent();
		BindingContext = new MovieDetailViewModel(Navigation,movieDetail);
	}
}
