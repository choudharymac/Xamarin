using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;

namespace Xamarin_App
{
    [Activity(Label = "Xamarin_App", MainLauncher = true, Icon = "@drawable/icon", Theme="@android:style/Theme.DeviceDefault.Light.NoActionBar")]
    public class MainActivity : Activity
    {
        static readonly string TAG = "Debug App:";
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
        }
        protected override void OnResume()
        {
            base.OnResume();

            Task startupWork = new Task(() => {
                Android.Util.Log.Debug(TAG, "Performing some startup work that takes a bit of time.");
                Task.Delay(10000);  // Simulate a bit of startup work.
                Android.Util.Log.Debug(TAG, "Working in the background - important stuff.");
            });

            startupWork.ContinueWith(t => {
                Android.Util.Log.Debug(TAG, "Work is finished - start Activity1.");
                System.Threading.Thread.Sleep(5000);
                StartActivity(new Intent(Application.Context, typeof(IntroActivity)));
            }, TaskScheduler.FromCurrentSynchronizationContext());

            startupWork.Start();
        }
    }
}

