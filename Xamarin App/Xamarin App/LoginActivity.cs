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
    [Activity(Label = "Login",Theme ="@style/Theme.Custom")]
    public class LoginActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here    // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.login);

            // Get our button from the layout resource,
            // and attach an event to it
            Button loginButton = FindViewById<Button>(Resource.Id.button1);
            var tbun = FindViewById<EditText>(Resource.Id.editText1).Text;
            var pbun = FindViewById<EditText>(Resource.Id.editText2).Text;
            loginButton.Click += (object sender, EventArgs e) =>
            {
                if (tbun.Equals("")||pbun.Equals(""))
                    Toast.MakeText(this, "Enter Details or Press Skip ", ToastLength.Long).Show();
                else
                {
                    Toast.MakeText(this, "Welcome " + tbun, ToastLength.Long).Show();
                    var intent = new Intent(this, typeof(Dashboard));
                    StartActivity(intent); }
            };
            Button skipButton = FindViewById<Button>(Resource.Id.button2);
            skipButton.Click += (object sender, EventArgs e) =>
            {
                Toast.MakeText(this, "Welcome", ToastLength.Long).Show();
                var intent = new Intent(this, typeof(Dashboard));
                StartActivity(intent);
            };

        }
    }
}