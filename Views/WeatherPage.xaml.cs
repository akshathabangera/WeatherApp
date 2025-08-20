using WeatherApp.Models;

namespace WeatherApp.Views;

public partial class WeatherPage : ContentPage
{
    private readonly WeatherService _weatherService ;

    public WeatherPage(WeatherService weatherService)
    {
        InitializeComponent();
        _weatherService = weatherService;
    }

    private async void OnGetWeatherClicked(object sender, EventArgs e)
    {
        string city = CityEntry.Text;
        if (string.IsNullOrWhiteSpace(city))
        {
            await DisplayAlert("Error", "Please enter a city name.", "OK");
            return;
        }

        try
        {
            WeatherResponse weather = await _weatherService.GetWeatherAsync(city);
            CityLabel.Text = weather.Location.Name;
            TemperatureLabel.Text = $"Temperature: {weather.Current.Temp_C} C";
            ConditionLabel.Text = $"Condition: {weather.Current.Condition.Text}";
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Could not retrieve weather: {ex.Message}", "OK");
        }
    }
}