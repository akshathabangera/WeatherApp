// Services/WeatherService.cs
using Newtonsoft.Json;
using WeatherApp.Models;
using static System.Net.WebRequestMethods;

public class WeatherService
{
    private const string ApiKey = "498108ca9f574d4f8a6132106251908"; 
    private const string BaseUrl = "https://api.weatherapi.com/v1/current.json";

    public async Task<WeatherResponse> GetWeatherAsync(string city)
    {
        using (HttpClient client = new HttpClient())
        {
            string url = $"{BaseUrl}?key={ApiKey}&q={city}&lang=en";

            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<WeatherResponse>(json);
        }
    }
}