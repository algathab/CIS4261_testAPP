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

namespace App1.Droid
{
    [Activity(Label = "Activity2")]
    public class Activity2 : Activity
    {
        ISharedPreferences pref;
        ISharedPreferencesEditor editor;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layout2);
            ImageView iv = FindViewById<ImageView> (Resource.Id.imageView1);
            iv.SetImageResource(Resource.Drawable.baugh);
            pref = GetSharedPreferences("info", FileCreationMode.Private);
            editor = pref.Edit();

            TextView tx = FindViewById<TextView>(Resource.Id.textView1);
            tx.Text = "Baugh";
            RatingBar rb = FindViewById<RatingBar>(Resource.Id.ratingBar1);
            rb.Rating = float.Parse(pref.GetString("rate", "0"));
            rb.RatingBarChange += Rb_RatingBarChange;
            // Create your application here
        }

        private void Rb_RatingBarChange(object sender, RatingBar.RatingBarChangeEventArgs e)
        {
            editor.PutString("rate", e.Rating.ToString());
            editor.Apply();
            editor.Commit();
        }
    }
}