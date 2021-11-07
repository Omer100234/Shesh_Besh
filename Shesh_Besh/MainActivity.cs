using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;


namespace Shesh_Besh
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        
        Button b1, b2 , b3;
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

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}