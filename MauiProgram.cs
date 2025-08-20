using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WeatherApp.Config;
using WeatherApp.Services;
using WeatherApp.Views;


namespace WeatherApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });


            builder.Services.AddTransient<WeatherService>();      
            builder.Services.AddTransient<WeatherPage>();

        
            builder.Services.AddTransient<NotesService>();     
            builder.Services.AddTransient<NotesPageViewModel>();
            builder.Services.AddTransient<NotesPage>();

           // builder.Services.AddHttpClient<NotesService>();

            builder.Services.AddHttpClient<NotesService>(client =>
            {
                client.BaseAddress = new Uri("http://192.168.1.195:8080/");
            });

            builder.Services.AddHttpClient<WeatherService>(client =>
            {
                client.BaseAddress = new Uri("https://api.weatherapi.com/v1/current.json");
            });


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
