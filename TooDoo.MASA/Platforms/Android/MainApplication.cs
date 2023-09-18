using Android.App;
using Android.Runtime;

namespace TooDoo.MASA
{
    [Application]
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle , JniHandleOwnership ownership)
            : base(handle , ownership)
        {
        }

        protected override MauiApp CreateMauiApp( ) => MauiProgram.CreateMauiApp();
    }
}