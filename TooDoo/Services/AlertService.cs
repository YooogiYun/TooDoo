using TooDooMBH.Common.Interfaces;

namespace TooDoo.Services;

public class AlertService : IAlertService
{
    private readonly Page _page;
    public AlertService( )
    {
        _page = App.Current.MainPage;
    }
    public async Task AlertAsync(string msg , string title = "Alert" , string buttonName = "OK")
    {
        await _page.DisplayAlert(msg , title , buttonName);
    }

    public async Task<string?> PromptAsync(string msg , string title)
    {
        return await _page.DisplayPromptAsync(msg , title);
    }
}
