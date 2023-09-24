namespace TooDooMBH.Common.Interfaces;

public interface IPlatformService
{
    bool IsBrower { get; }

    Task<string?> ChooseFromOptionsAsync(string title , params string[] options);

    Task CopyToClipboardAsync(string text);
    Task ShareAsync(string text);
}