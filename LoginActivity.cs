﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;

using AndroidX.AppCompat.App;

namespace XA2_443_SQLDB1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class LoginActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_login);

            var username = FindViewById<EditText>(Resource.Id.username);
            var password = FindViewById<EditText>(Resource.Id.password);
            var login = FindViewById<Button>(Resource.Id.login);
            var clear = FindViewById<Button>(Resource.Id.clear);
            var close = FindViewById<Button>(Resource.Id.close);
            var create = FindViewById<Button>(Resource.Id.create);

            login.Click += delegate
            {
                if (!string.IsNullOrEmpty(username.Text) && !string.IsNullOrEmpty(password.Text))
                {
                    var sq = new UserOperations();
                    var user = sq.LoginUser(username.Text, password.Text);
                    if (user != null)
                    {
                        Intent i = new Intent(this, typeof(ShowActivity));
                        i.PutExtra("Id", user.Id + "");
                        StartActivity(i);
                    }
                    else
                        Toast.MakeText(this, "Username or Password is not correct !!!", ToastLength.Long).Show();
                }
                else
                    Toast.MakeText(this, "Username or Password is Empty !!!", ToastLength.Long).Show();
            };

            clear.Click += delegate
            {
                username.Text = "";
                password.Text = "";
            };
            close.Click += delegate
            {
                System.Environment.Exit(0);
            };
            create.Click += delegate
            {
                var i = new Intent(this, typeof(CreateActivity));
                StartActivity(i);
            };




        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}