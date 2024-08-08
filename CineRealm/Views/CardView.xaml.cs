namespace CineRealm.Views;

public partial class CardView : ContentView
{
    public static readonly BindableProperty MovieTitleProperty = BindableProperty.Create(nameof(MovieTitle), typeof(string), typeof(CardView), string.Empty);
    public string MovieTitle
    {
        get => (string)GetValue(CardView.MovieTitleProperty);
        set => SetValue(CardView.MovieTitleProperty, value);
    }

    public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(nameof(ImageSource), typeof(string), typeof(CardView), string.Empty);
    public string ImageSource
    {
        get => (string)GetValue(CardView.ImageSourceProperty);
        set => SetValue(CardView.ImageSourceProperty, value);
    }

    public static readonly BindableProperty MovieDurationProperty = BindableProperty.Create(nameof(MovieDuration), typeof(string), typeof(CardView), string.Empty);
    public string MovieDuration
    {
        get => (string)GetValue(CardView.MovieDurationProperty);
        set => SetValue(CardView.MovieDurationProperty, value);
    }

    public static readonly BindableProperty MovieRatingProperty = BindableProperty.Create(nameof(MovieRating), typeof(string), typeof(CardView), string.Empty);
    public String MovieRating
    {
        get => (String)GetValue(CardView.MovieRatingProperty);
        set => SetValue(CardView.MovieRatingProperty, value);
    }
    public CardView()
	{
		InitializeComponent();
	}
}