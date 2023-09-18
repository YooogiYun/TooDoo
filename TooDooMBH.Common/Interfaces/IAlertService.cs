namespace TooDooMBH.Common.Interfaces;

public interface IAlertService
{
    Task<string?> PromptAsync(string title , string msg);
    Task AlertAsync(string title , string msg , string buttonName = "OK");
}


