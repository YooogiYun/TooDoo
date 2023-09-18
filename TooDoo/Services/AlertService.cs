using TooDooMBH.Common.Interfaces;

namespace TooDoo.Services;

public class AlertService : IAlertService
{
    private readonly Page _page;
    public AlertService( )
    {
        _page = App.Current.MainPage;
    }
    public async Task AlertAsync(string title , string msg , string buttonName = "OK")
    {
        await _page.DisplayAlert(title , msg , buttonName);
    }

    public async Task<string?> PromptAsync(string title , string msg)
    {
        return await _page.DisplayPromptAsync(title , msg);
    }
}
