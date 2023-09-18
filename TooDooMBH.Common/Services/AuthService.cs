using TooDooMBH.Common.Interfaces;

namespace TooDooMBH.Common.Services;


public class AuthService
{
    private readonly IAlertService _alertService;
    private readonly IStorageService _storageService;

    public AuthService(IAlertService alertService , IStorageService storageService)
    {
        this._alertService = alertService;
        this._storageService = storageService;
    }
    public async Task<string?> GetUserName( )
    {
        var name = await _storageService.GetAsync(AppConstants.StorageKeys.Username);

        if(string.IsNullOrWhiteSpace(name))
        {
            int maxTry = 3;
            do
            {
                name = await _alertService.PromptAsync("Welcome" , "Please enter your name.");
            } while(string.IsNullOrWhiteSpace(name) && (--maxTry) > 0);

            if(string.IsNullOrWhiteSpace(name))
            {
                await _alertService.AlertAsync("Error" , "Your name is required for the coninuing using." , "OK");
                return null;
            }
            // We have user name so that we can continue that.
            await _storageService.SetAsync(AppConstants.StorageKeys.Username , name);
        }
        return name;
    }
}

