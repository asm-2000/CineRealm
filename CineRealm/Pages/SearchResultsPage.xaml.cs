using CineRealm.ViewModels;

namespace CineRealm.Pages;

public partial class SearchResultsPage : ContentPage
{
	public SearchResultsPage()
	{
		InitializeComponent();
		BindingContext = new SearchResultsViewModel(Navigation);
	}
}
