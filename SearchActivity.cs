using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XA2_443_SQLDB1
{
    [Activity(Label = "SearchActivity")]
    public class SearchActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            SetContentView(Resource.Layout.activity_search);

          
            var myCity = FindViewById<EditText>(Resource.Id.myCity);

            var show = FindViewById<TextView>(Resource.Id.show);

            var back = FindViewById<Button>(Resource.Id.back);
            var logout = FindViewById<Button>(Resource.Id.logout);
            var search = FindViewById<Button>(Resource.Id.search);

            var sq = new UserOperations();                     

            search.Click += delegate
            {
                var tables = sq.SearchCity(myCity.Text);
                string data = "";
                foreach (var s in tables)
                    data += s.Id + "\t" + s.Username + "\t" + s.Password + "\t" + s.City + "\n";
                show.Text = data;
            };

            logout.Click += delegate
            {
                Intent i = new Intent(this, typeof(LoginActivity));
                StartActivity(i);
            };
            back.Click += delegate
            {
                Intent i = new Intent(this, typeof(ShowActivity));
                StartActivity(i);
            };
        }
    }
}