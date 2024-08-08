using CommunityToolkit.Mvvm.ComponentModel;

namespace CineRealm.ViewModels
{
    public partial class SearchResultsViewModel: ObservableObject
    {
        private INavigation _navigation;

        public SearchResultsViewModel(INavigation navigation)
        {
            _navigation = navigation;
        }
    }
}
