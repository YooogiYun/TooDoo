using Foundation;

namespace TooDoo.MASA
{
    [Register("AppDelegate")]
    public class AppDelegate : MauiUIApplicationDelegate
    {
        protected override MauiApp CreateMauiApp( ) => MauiProgram.CreateMauiApp();
    }
}