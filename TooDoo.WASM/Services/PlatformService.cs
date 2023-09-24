using Microsoft.JSInterop;
using TooDoo.WASM.JSConstants;
using TooDooMBH.Common.Interfaces;

namespace TooDoo.WASM.Services;

public class PlatformService : IPlatformService
{
    private readonly IJSRuntime _jsRuntime;

    public bool IsBrower => true;


    public PlatformService(IJSRuntime jsRuntime)
    {
        this._jsRuntime = jsRuntime;
    }

    public Task<string?> ChooseFromOptionsAsync(string title , params string[] options)
    {
        throw new NotImplementedException();
    }

    public async Task CopyToClipboardAsync(string text)
    {
        await _jsRuntime.InvokeVoidAsync(JSRuntimeFuncs.writeTextToClipboardFunc , text);
    }

    public Task ShareAsync(string text)
    {
        throw new NotImplementedException();
    }
}
