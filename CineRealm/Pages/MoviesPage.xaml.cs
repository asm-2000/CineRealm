using CineRealm.ViewModels;

namespace CineRealm.Pages;

public partial class MoviesPage : ContentPage
{
	public MoviesPage()
	{
		InitializeComponent();
		BindingContext = new MoviesViewModel(Navigation);
	}
}