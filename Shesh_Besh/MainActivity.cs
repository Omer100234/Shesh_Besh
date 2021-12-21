﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;


namespace Shesh_Besh
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Dialog d;
        
        Button b1, b2 , b3;
        SeekBar sb1;
        public static MyService ms1;
        public static Intent intent;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            //play vs ai
            b1 = (Button)FindViewById(Resource.Id.bt1);
            b1.Click += B1_Click;


            //play vs person
            b2 = (Button)FindViewById(Resource.Id.bt2);
            b2.Click += B2_Click;


            //leaderboard
            b3 = (Button)FindViewById(Resource.Id.bt3);
            b3.Click += B3_Click;

            intent = new Intent(this, typeof(MyService));
            
            StartService(intent);
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.XMLFile1, menu);
            return true;

        }
        public override bool OnOptionsItemSelected(Android.Views.IMenuItem item)
        {
            base.OnOptionsItemSelected(item);
            if (item.ItemId == Resource.Id.op1)
            {
                d = new Dialog(this);
                d.SetContentView(Resource.Layout.scrlview);
                d.SetTitle("submit");
                d.SetCancelable(false);
                sb1 = (SeekBar)d.FindViewById(Resource.Id.sv1);
                d.Show();
                sb1.Drag += Sb1_Drag;
            }
            
            return true;
        }

        private void Sb1_Drag(object sender, View.DragEventArgs e)
        {
            MyService.changeVolume(sb1.Progress);
        }

        
        private void B2_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(b1v1Activity));
            StartActivityForResult(intent, 0);
        }

        private void B3_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(LeaderbActivity));
            StartActivityForResult(intent, 0);
        }

        private void B1_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ba1Activity));
            StartActivityForResult(intent, 0);
        }

        

        protected override void OnDestroy()
        {
            StopService(intent);
            base.OnDestroy();
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}