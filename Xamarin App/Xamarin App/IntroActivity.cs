using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Xamarin_App
{
    [Activity(Label = "Intro",Theme ="@style/Theme.Custom")]
    public class IntroActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.intro);
            Button loginButton = FindViewById<Button>(Resource.Id.button1);
            loginButton.Click += (object sender, EventArgs e) =>
            {
                var intent = new Intent(this, typeof(LoginActivity));
                StartActivity(intent);
            };
        }
    }
}