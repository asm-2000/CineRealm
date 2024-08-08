using CineRealm.ViewModels;

namespace CineRealm.Pages;

public partial class TVSeriesPage : ContentPage
{
	public TVSeriesPage()
	{
		InitializeComponent();
		BindingContext = new SeriesViewModel(Navigation);
	}
}
