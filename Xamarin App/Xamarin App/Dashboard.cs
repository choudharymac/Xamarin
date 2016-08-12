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
    [Activity(Label = "Dashboard",Theme ="@style/Theme.Custom")]
    public class Dashboard : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Dashboard);

            var gridview = FindViewById<GridView>(Resource.Id.gridview);
            gridview.Adapter = new ImageAdapter(this);

            gridview.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args) {
                Toast.MakeText(this, args.Position.ToString(), ToastLength.Short).Show();
            };
        }
    }
    public class ImageAdapter : BaseAdapter
    {
        Activity c;

        public ImageAdapter(Activity c)
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
            ImageView imageView;
            TextView tx;

            var view = (convertView ??
                    this.c.LayoutInflater.Inflate(
                    Resource.Layout.grid_element,
                    parent,
                    false));

            return view;
        }

        // references to our images
        int[] thumbIds = {
        Resource.Drawable.ic_email, Resource.Drawable.ic_lock,
      
    };
    }
}