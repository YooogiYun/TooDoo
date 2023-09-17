namespace TooDoo.Pages;

public partial class NativeContent : ContentView
{
    public NativeContent( )
    {
        InitializeComponent();
    }

    int count = 0;

    private void OnCounterClicked(object sender , EventArgs e)
    {
        count++;

        if( count == 1 )
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";
    }
}