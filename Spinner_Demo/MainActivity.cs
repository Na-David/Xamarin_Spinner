using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using System;
using System.IO;

namespace Spinner_Demo
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView detail;
        ImageView img;
        Spinner spinner;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            detail = FindViewById<TextView>(Resource.Id.detail);
            img = FindViewById<ImageView>(Resource.Id.image);
            spinner = FindViewById<Spinner>(Resource.Id.spinner);

            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.City_Names, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;

            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);

        }

        public void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            string content;

            if(String.Format("{0}", spinner.GetItemAtPosition(e.Position)) == "Auckland")
            {
                img.SetImageResource(Resource.Drawable.Auckland);
                using (StreamReader sr = new StreamReader(Assets.Open("Auckland.txt")))
                {
                    content = sr.ReadToEnd();
                }
                detail.Text = content;
            }
            else if (String.Format("{0}", spinner.GetItemAtPosition(e.Position)) == "Wellington")
            {
                img.SetImageResource(Resource.Drawable.wellington);
                detail.Text = "Selected City Detail";

                using (StreamReader sr = new StreamReader(Assets.Open("Wellington.txt")))
                {
                    content = sr.ReadToEnd();
                }
                detail.Text = content;
            }
            else if (String.Format("{0}", spinner.GetItemAtPosition(e.Position)) == "ChristChurch")
            {
                img.SetImageResource(Resource.Drawable.CHCH);
                detail.Text = "Selected City Detail";

                using (StreamReader sr = new StreamReader(Assets.Open("CHCH.txt")))
                {
                    content = sr.ReadToEnd();
                }
                detail.Text = content;
            }

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}