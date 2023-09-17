using Foundation;

namespace TooDoo
{
    [Register("AppDelegate")]
    public class AppDelegate : MauiUIApplicationDelegate
    {
        protected override MauiApp CreateMauiApp( ) => MauiProgram.CreateMauiApp();
    }
}