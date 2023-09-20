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
    public async Task AlertAsync(string title , string msg , string buttonName = "Useless Param")
    {
        await this._jsRuntime.InvokeVoidAsync(JSRuntimeFuncs.alertFunc , $"{title}\n{msg}");
    }

    public async Task<string?> PromptAsync(string title , string msg)
    {
        return await this._jsRuntime.InvokeAsync<string?>(JSRuntimeFuncs.promptFunc , $"{title}\n{msg}");
    }
}