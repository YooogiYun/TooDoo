namespace TooDooMBH.Common.Interfaces;

public interface IStorageService
{
    Task SetAsync(string key , string value);
    Task<string?> GetAsync(string key);
    Task RemoveAsync(string key);
    Task RemoveAllAsync( );
}
