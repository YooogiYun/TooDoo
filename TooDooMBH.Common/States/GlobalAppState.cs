using System.ComponentModel;

namespace TooDooMBH.Common.States;

public class GlobalAppState : INotifyPropertyChanged
{
    private bool _isInitializing = true;

    public bool IsInitializing
    {
        get { return _isInitializing; }
        set
        {
            _isInitializing = value;
            PropertyChanged?.Invoke(this , new PropertyChangedEventArgs(nameof(IsInitializing)));
        }
    }

    private string? _errorMessage;

    public string? ErrorMessage
    {
        get { return _errorMessage; }
        set
        {
            _errorMessage = value;
            PropertyChanged?.Invoke(this , new PropertyChangedEventArgs(nameof(ErrorMessage)));
        }
    }


    public event PropertyChangedEventHandler? PropertyChanged;
}
