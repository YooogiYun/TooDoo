namespace TooDoo.WASM.JSConstants;

public struct JSRuntimeFuncs
{
    public const string alertFunc = "window.alert";
    public const string promptFunc = "window.prompt";
    public const string confirmFunc = "window.confirm";

    public const string writeTextToClipboardFunc = "navigator.clipboard.writeText";

    public const string localStorage = "window.localStorage";
    //public const string setLocalStorageItem = $"{localStorage}.setItem";
    //public const string getLocalStorageItem = $"{localStorage}.getItem";
}
