using Microsoft.Extensions.Logging;
using TooDoo.MASA.Data;

namespace TooDoo.MASA;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp( )
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf" , "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif
        builder.Services.AddMyServices();

        builder.Services.AddSingleton<WeatherForecastService>();

        return builder.Build();
    }
    public static IServiceCollection AddMyServices(this IServiceCollection services)
    {
        services.AddMasaBlazor();
        return services;
    }
}