using Android.App;
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
        
        Button b1, b2 , b3, menub1;
        SeekBar sb1;
        public static bool hasMusicStarted;
        public static MyService ms1;
        public static Intent intent;
        int time;
        char winner;
        public static ISharedPreferences totals; 

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
            totals = this.GetSharedPreferences("totals", FileCreationMode.Private);
            time = Intent.GetIntExtra("timer", 0);
            winner = Intent.GetCharExtra("winner", 'N');
            if(time!=0)
            {
                Toast.MakeText(this, "time it took: " + time, ToastLength.Short).Show();
            }
            if (winner!='N')
            {
                var editor = totals.Edit();
                int gp = totals.GetInt("gp", 0);
                editor.PutInt("gp", gp + 1);
                if (winner == 'W')
                {
                    int ww = totals.GetInt("ww", 0);
                    editor.PutInt("ww", ww + 1);
                }
                else
                {
                    int bw = totals.GetInt("bw", 0);
                    editor.PutInt("bw", bw + 1);
                }
                editor.Commit();

            }
        }

        protected override void OnPause()
        {
            PauseMusic();
            base.OnPause();
        }

        protected override void OnResume()
        {
            ResumeMusic();
            base.OnResume();
        }


        public void ResumeMusic() // move to mainactivity
        {
            Intent i = new Intent("music");
            i.PutExtra("action", 1); // 1 to turn on
            SendBroadcast(i);
        }

        public void PauseMusic() // move to main
        {
            Intent i = new Intent("music");
            i.PutExtra("action", 0); // 0 to turn on
            SendBroadcast(i);
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
                sb1.Progress = 50;
                menub1 = (Button)d.FindViewById(Resource.Id.menubt1);
                d.Show();
                menub1.Click += B1_Click1;
                sb1.ProgressChanged += Sb1_ProgressChanged;
            }
            
            return true;
        }

        private void Sb1_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            MyService.setVolume(sb1.Progress);
        }

        private void B1_Click1(object sender, System.EventArgs e)
        {
            d.Dismiss();
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