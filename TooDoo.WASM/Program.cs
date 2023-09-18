using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TooDoo.WASM;
using TooDoo.WASM.Services;
using TooDooMBH.Common.Interfaces;
using TooDooMBH.Common.Services;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        // My Services...
        builder.Services.AddSingleton<IAlertService , AlertService>()
                        .AddSingleton<IStorageService , StorageService>();
        builder.Services.AddTransient<AuthService>();

        await builder.Build().RunAsync();
    }
}