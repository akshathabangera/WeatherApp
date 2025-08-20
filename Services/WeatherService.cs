using Newtonsoft.Json;
using WeatherApp.Config;
using WeatherApp.Models;
using WeatherApp.Services;
using static System.Net.WebRequestMethods;

public class WeatherService
{    
    private const string BaseUrl = "https://api.weatherapi.com/v1/current.json";  

    private readonly ApiKeyService _apiKeyService = new();   
    public async Task<WeatherResponse> GetWeatherAsync(string city)
    {
        using (HttpClient client = new HttpClient())
        {

            var apiKey = await _apiKeyService.GetApiKeyAsync();
            if (string.IsNullOrEmpty(apiKey))
                throw new Exception("API Key not found. Please save it first.");


            string url = $"{BaseUrl}?key={apiKey}&q={city}&lang=en";

            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
           
            return JsonConvert.DeserializeObject<WeatherResponse>(json);
        }
    }
}