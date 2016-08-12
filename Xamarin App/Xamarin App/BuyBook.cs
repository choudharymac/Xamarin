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
    [Activity(Label = "BuyBook",Theme="@style/Theme.Custom")]
    public class BuyBook : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.buybook);

            var gridview = FindViewById<GridView>(Resource.Id.gridview);
            gridview.Adapter = new BookAdapter(this);

            gridview.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args)
            {
                Toast.MakeText(this, args.Position ,ToastLength.Short).Show();
            };
        }
    }
    public class BookAdapter : BaseAdapter
    {
        Activity c;
        ImageView imageView;
        TextView tx,txa;
        Button bt;
        RelativeLayout rlayout;

        public BookAdapter(Activity c)
        {
            this.c = c;
        }

        public override int Count
        {
            get { return thumbIds.Length; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return 0;
        }

        // create a new ImageView for each item referenced by the Adapter
        public override View GetView(int position, View convertView, ViewGroup parent)
        {


            View view = (convertView ??
                    this.c.LayoutInflater.Inflate(
                    Resource.Layout.buybook_element,
                    parent,
                    false));
            rlayout = view.FindViewById<RelativeLayout>(Resource.Id.image1);
            imageView = view.FindViewById<ImageView>(Resource.Id.imageView1);
            bt = view.FindViewById<Button>(Resource.Id.button1);
            tx = view.FindViewById<TextView>(Resource.Id.textView1);
            txa = view.FindViewById<TextView>(Resource.Id.textView2);
            imageView.SetImageResource(thumbIds[position]);
            txa.Text = yourArray[position];
            tx.Text = array_authors[position];
            bt.SetTag(Resource.Id.button1, position);
            bt.Click += (object sender, EventArgs e) =>
            {
                int pos = (int)(((Button)sender).GetTag(Resource.Id.button1));
                Class1.Expired = pos+1;
                Toast.MakeText(c,"You have booked "+ yourArray[position], ToastLength.Short).Show();
                c.Finish();
            };
            return view;
        }

        // references to our images
        int[] thumbIds = {
        Resource.Drawable.ic_book1, Resource.Drawable.ic_book3, Resource.Drawable.ic_book5, Resource.Drawable.ic_book2, Resource.Drawable.ic_book4
    };
        String[] yourArray = { "Creating Book Cover", "The Monk Who Sold His Ferrari", "Core Computer Science", "Sharpe's Siege", "The Life Changing Lessons" };
        String [] array_authors = {
        "By Jeff Barr","By Robin Sharma","By Ravinder Kumar","By Bernanrd Cornwell","By Robin Sharma"
    };
    }
}