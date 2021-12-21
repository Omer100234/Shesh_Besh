using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Shesh_Besh
{
    [Service]
    public class MyService : Service
    {
        int counter;
        MyHandler myhandler;
        MediaPlayer mp;
        static AudioManager am;
        public override void OnCreate()
        {
            base.OnCreate();
            myhandler = new MyHandler(this);
            am = (AudioManager)GetSystemService(Context.AudioService);
            int max = am.GetStreamMaxVolume(Stream.Music);
            am.SetStreamVolume(Stream.Music, max / 2, 0);
            mp = MediaPlayer.Create(this, Resource.Raw.song);
        }
        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            
            Thread t = new Thread(Run);
            t.Start();
            return base.OnStartCommand(intent, flags, startId);
        }

        private void Run()
        {
           
                mp.Start();
            
            
        }

        public override void OnDestroy()
        { 
            mp.Stop();
            base.OnDestroy();
        }
        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public static void changeVolume(int x)
        {
            am.SetStreamVolume(Stream.Music, x, 0);
        }
    }
}