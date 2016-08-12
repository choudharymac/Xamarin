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
    [Activity(Label = "View Book", Theme = "@style/Theme.Custom")]
    public class ViewBook : Activity
    {
        ImageView imageView;
        TextView tx, txa;
        Button bt;
        RelativeLayout rlayout;
        int[] thumbIds = {
        Resource.Drawable.ic_book1, Resource.Drawable.ic_book3, Resource.Drawable.ic_book5, Resource.Drawable.ic_book2, Resource.Drawable.ic_book4
    };
        String[] yourArray = { "Creating Book Cover", "The Monk Who Sold His Ferrari", "Core Computer Science", "Sharpe's Siege", "The Life Changing Lessons" };
        String[] array_authors = {
        "By Jeff Barr","By Robin Sharma","By Ravinder Kumar","By Bernanrd Cornwell","By Robin Sharma"
    };
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            if(Class1.Expired > 1)
            {
               // Toast.MakeText(this, "You have booked "+ Class1.Expired, ToastLength.Short).Show();
                SetContentView(Resource.Layout.buybook_element);
                rlayout = FindViewById<RelativeLayout>(Resource.Id.image1);
                imageView = FindViewById<ImageView>(Resource.Id.imageView1);
                bt = FindViewById<Button>(Resource.Id.button1);
                tx = FindViewById<TextView>(Resource.Id.textView1);
                txa = FindViewById<TextView>(Resource.Id.textView2);
                imageView.SetImageResource(thumbIds[Class1.Expired-1]);
                txa.Text = yourArray[Class1.Expired-1];
                tx.Text = array_authors[Class1.Expired-1];
                bt.Visibility = ViewStates.Invisible;

            }
            // Create your application here
        }
    }
}