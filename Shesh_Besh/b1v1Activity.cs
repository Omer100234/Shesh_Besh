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


namespace Shesh_Besh
{
    [Activity(Label = "b1v1Activity")]
    public class b1v1Activity : Activity
    {
        MyHandler mh1;
        static MyTimer mt1;
        Board1v1 b1v1;
        FrameLayout fl1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.b1v1Layout);
            b1v1 = new Board1v1(this, 'n', Android.Graphics.Color.Red, Android.Graphics.Color.Black);

            fl1 = (FrameLayout)FindViewById(Resource.Id.fl1);
            fl1.AddView(b1v1);
            b1v1.winHandler += gys;


        }

        
        

        
        private void gys(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            intent.PutExtra("timer", b1v1.getTime());
            intent.PutExtra("winner", b1v1.getWinner());
            StartActivity(intent);
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







    }
}