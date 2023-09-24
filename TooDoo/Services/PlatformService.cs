using TooDooMBH.Common.Interfaces;

namespace TooDoo.Services;

public class PlatformService : IPlatformService
{
    private readonly Page _page;

    public PlatformService( )
    {
        _page = App.Current.MainPage;
    }
    public bool IsBrower => false;
    public async Task<string?> ChooseFromOptionsAsync(string title , params string[] options)
    {
        return await _page.DisplayActionSheet(title , "cancel" , null , options);
    }

    public async Task CopyToClipboardAsync(string text)
    {
        await Clipboard.Default.SetTextAsync(text);
    }

    public async Task ShareAsync(string text)
    {
        await Share.Default.RequestAsync(text);
    }
}
