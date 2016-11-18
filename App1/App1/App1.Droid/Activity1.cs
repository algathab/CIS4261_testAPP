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
    [Activity(Label = "Activity1")]
    public class Activity1 : Activity
    {
        List<string> st;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layout1);

            ListView lv = FindViewById<ListView>(Resource.Id.listView1);
            st = new List<string>();
            st.Add("Bough");
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, st);
            lv.Adapter = adapter;

            lv.ItemClick += Lv_ItemClick;
            // Create your application here
        }

        private void Lv_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Intent intent = new Intent(this, typeof(Activity2));
            StartActivity(intent);
        }
    }
}