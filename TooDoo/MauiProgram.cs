using CommunityToolkit.Maui;
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
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf" , "OpenSansRegular");
            })
            ;

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton<WeatherForecastService>();

        // 增加 BootstrapBlazor 组件服务
        builder.Services.AddBootstrapBlazor();


        // 增加 个人 服务
        builder.AddMyServices();

        return builder.Build();
    }

    public static MauiAppBuilder AddMyServices(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<IAlertService , AlertService>()
                        .AddSingleton<IStorageService , StorageService>()
                        .AddSingleton<IPlatformService , PlatformService>();
        builder.Services.AddTransient<AuthService>();
        builder.Services.AddSingleton<NotesService>();
        //services.AddScoped<IResultDialog>();
        //services.AddTransient<DialogService>();
        //services.AddTransient<ToastService>();
        return builder;
    }


}