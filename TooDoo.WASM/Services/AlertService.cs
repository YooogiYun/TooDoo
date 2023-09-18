using Microsoft.JSInterop;
using TooDoo.WASM.JSConstants;
using TooDooMBH.Common.Interfaces;

namespace TooDoo.WASM.Services;

public class AlertService : IAlertService
{
    private readonly IJSRuntime _jsRuntime;

    public AlertService(IJSRuntime jsRuntime)
    {
        this._jsRuntime = jsRuntime;
    }
    public async Task AlertAsync(string msg , string title = "Alert" , string buttonName = "Useless Param")
    {
        await _jsRuntime.InvokeVoidAsync(JSRuntimeFuncs.alertFunc , $"{title}\n{msg}");
    }

    public async Task<string?> PromptAsync(string msg , string title)
    {
        return await _jsRuntime.InvokeAsync<string?>(JSRuntimeFuncs.promptFunc , $"{title}\n{msg}");
    }
}