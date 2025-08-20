using Microsoft.Maui.Storage;
using System.IO;
using System.Text.Json;
using WeatherApp.Config;

public static class ConfigLoader
{
    public static async Task<WeatherApiConfig> LoadWeatherConfigAsync()
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync("appsettings.json");
        using var reader = new StreamReader(stream);
        string json = await reader.ReadToEndAsync();

        var root = JsonSerializer.Deserialize<JsonElement>(json);
        return new WeatherApiConfig
        {
            BaseUrl = root.GetProperty("WeatherApi").GetProperty("BaseUrl").GetString(),
            ApiKey = root.GetProperty("WeatherApi").GetProperty("ApiKey").GetString()
        };
    }
}
