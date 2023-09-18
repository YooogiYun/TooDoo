namespace TooDooMBH.Common.Interfaces;

public interface IAlertService
{
    Task<string?> PromptAsync(string msg , string title);
    Task AlertAsync(string msg , string title = "Alert" , string buttonName = "OK");

}


