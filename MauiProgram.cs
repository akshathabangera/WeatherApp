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

            //builder.Services.AddSingleton<ApiKeyService>(DependencyService.Get<ApiKeyService>());
            // builder.Services.AddSingleton<WeatherService>();

            builder.Services.AddTransient<WeatherService>();      
            builder.Services.AddTransient<WeatherPage>();

        
            builder.Services.AddSingleton<NotesService>();     
            builder.Services.AddTransient<NotesPageViewModel>();
            builder.Services.AddTransient<NotesPage>();

            builder.Services.AddHttpClient<NotesService>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
