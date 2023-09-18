using Microsoft.Extensions.Logging;
using TooDoo.Data;
using TooDoo.Services;
using TooDooMBH.Common.Interfaces;
using TooDooMBH.Common.Services;

namespace TooDoo;

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
        builder.Services.AddSingleton<WeatherForecastService>();

        // 增加 BootstrapBlazor 组件服务
        builder.Services.AddBootstrapBlazor();
        // 增加 验证 服务
        builder.Services.AddMyServices();

        return builder.Build();
    }

    public static IServiceCollection AddMyServices(this IServiceCollection services)
    {
        services.AddSingleton<IAlertService , AlertService>()
                .AddSingleton<IStorageService , StorageService>();
        services.AddTransient<AuthService>();
        //services.AddScoped<IResultDialog>();
        //services.AddTransient<DialogService>();
        //services.AddTransient<ToastService>();
        return services;
    }


}