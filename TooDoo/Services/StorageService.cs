using TooDooMBH.Common.Interfaces;

namespace TooDoo.Services;

public class StorageService : IStorageService
{
    private readonly ISecureStorage _secureStorage;
    public StorageService( )
    {
        _secureStorage = SecureStorage.Default;
    }

    public async Task<string?> GetAsync(string key)
    {
        return await _secureStorage.GetAsync(key);
    }

    public async Task SetAsync(string key , string value)
    {
        await _secureStorage.SetAsync(key , value);
    }

    public async Task RemoveAsync(string key)
    {
        await Task.Run(( ) =>
        {
            _secureStorage.Remove(key);
        });
    }
    public async Task RemoveAllAsync( )
    {
        await Task.Run(( ) =>
        {
            _secureStorage.RemoveAll();
        });
    }
}
