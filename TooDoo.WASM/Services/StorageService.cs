using Microsoft.JSInterop;
using TooDoo.WASM.JSConstants;
using TooDooMBH.Common.Interfaces;

namespace TooDoo.WASM.Services;

public class StorageService : IStorageService
{
    private readonly IJSRuntime _jsRuntime;
    private readonly string _storageName;

    public StorageService(IJSRuntime jsRuntime , string storageName = JSRuntimeFuncs.localStorage)
    {
        this._jsRuntime = jsRuntime;
        this._storageName = storageName;
    }

    public async Task<string?> GetAsync(string key)
    {
        return await _jsRuntime.InvokeAsync<string?>($"{_storageName}.getItem" , key);
    }

    public async Task SetAsync(string key , string value)
    {
        await _jsRuntime.InvokeVoidAsync($"{_storageName}.setItem" , key , value);
    }

    public async Task RemoveAsync(string key)
    {
        await _jsRuntime.InvokeVoidAsync($"{_storageName}.removeItem" , key);
    }

    public async Task RemoveAllAsync( )
    {
        await _jsRuntime.InvokeVoidAsync($"{_storageName}.clear");
    }
}
