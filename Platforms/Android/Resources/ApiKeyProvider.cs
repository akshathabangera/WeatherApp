#if ANDROID
using Android.App;
using WeatherApp.Services;
using Application = Android.App.Application;

[assembly: Microsoft.Maui.Controls.Dependency(typeof(WeatherApp.Platforms.Android.ApiKeyProvider))]
namespace WeatherApp.Platforms.Android
{
    public class ApiKeyProvider : ApiKeyService
    {
        public string GetWeatherApiKey()
        {
            return Application.Context.Resources.GetString(Resource.String.ApiKey);
        }
    }
}
#endif
