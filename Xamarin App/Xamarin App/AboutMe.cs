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
    [Activity(Label = "About Me",Theme = "@style/Theme.Custom")]
    public class AboutMe : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.intro);
            Button loginButton = FindViewById<Button>(Resource.Id.button1);
            loginButton.Visibility = ViewStates.Invisible;
            // Create your application here
        }
    }
}