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
        String[] yourArray = { "Buy Book", "View Order", "Book Selfie", "About Me", "New Relaease", "Audiable Book" };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Dashboard);

            var gridview = FindViewById<GridView>(Resource.Id.gridview);
            gridview.Adapter = new ImageAdapter(this);

            gridview.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args) {
                Toast.MakeText(this, yourArray[args.Position], ToastLength.Short).Show();
                switch (args.Position)
                {

                    case 0:
                        StartActivity(new Intent(Application.Context, typeof(BuyBook)));
                        break;
                    case 1:
                        StartActivity(new Intent(Application.Context, typeof(ViewBook)));
                        break;
                    case 2:
                        StartActivity(new Intent(Application.Context, typeof(Selfie)));
                        break;
                    case 3:
                        StartActivity(new Intent(Application.Context, typeof(AboutMe)));
                        break;
                    case 4:
                        StartActivity(new Intent(Application.Context, typeof(NewBook)));
                        break;
                    case 5:
                        StartActivity(new Intent(Application.Context, typeof(Hearit)));
                        break;
                }

            };
        }
    }
    public class ImageAdapter : BaseAdapter
    {
        Activity c;
        ImageView imageView;
        TextView tx;
        RelativeLayout rlayout;

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
            

            View view = (convertView ??
                    this.c.LayoutInflater.Inflate(
                    Resource.Layout.grid_element,
                    parent,
                    false));
            rlayout = view.FindViewById<RelativeLayout>(Resource.Id.image1);
            
            rlayout.SetBackgroundResource(img_colors[position]);
            imageView= view.FindViewById<ImageView>(Resource.Id.imageView1);
            tx = view.FindViewById<TextView>(Resource.Id.textView1);
            imageView.SetImageResource(thumbIds[position]);
            tx.Text=yourArray[position];
             return view;
        }

        // references to our images
        int[] thumbIds = {
        Resource.Drawable.ic_book, Resource.Drawable.ic_order,Resource.Drawable.ic_camera,Resource.Drawable.ic_about,Resource.Drawable.ic_new,Resource.Drawable.ic_record
    };
        String[] yourArray = { "Buy Book","View Order", "Book Selfie","About Me","New Relaease","Audiable Book" };
        int[] img_colors = {
        Resource.Color.yellow,Resource.Color.darkgey,Resource.Color.dgreen,Resource.Color.darkblue,Resource.Color.purple,Resource.Color.darkpink

    };
    }
}