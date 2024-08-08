using CineRealm.Pages;

namespace CineRealm
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MoviesPage), typeof(MoviesPage));
            Routing.RegisterRoute(nameof(TVSeriesPage),typeof(TVSeriesPage));
        }
    }
}
