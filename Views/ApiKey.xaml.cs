namespace WeatherApp.Views;

public partial class ApiKey : ContentPage
{
    private readonly ApiKeyService _apiKeyService = new();

    public ApiKey()
    {
        InitializeComponent();
    }

    // Save API Key
    private async void OnSaveApiKeyClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(ApiKeyEntry.Text))
        {
            await _apiKeyService.SaveApiKeyAsync(ApiKeyEntry.Text);
            await DisplayAlert("Success", "API Key saved securely!", "OK");
        }
        else
        {
            await DisplayAlert("Error", "Please enter an API key", "OK");
        }
    }  
    
}