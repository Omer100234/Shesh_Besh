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
        static AudioManager am;
        static MediaPlayer mp;
        public override void OnCreate()
        {
            base.OnCreate();
        }
        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            Thread t = new Thread(Run);
            t.Start();
            return base.OnStartCommand(intent, flags, startId);
        }
        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        private void Run()
        {
            if (!MainActivity.hasMusicStarted)
            {
                mp = MediaPlayer.Create(this, Resource.Raw.song);
                MainActivity.hasMusicStarted = true;
                am = (AudioManager)GetSystemService(Context.AudioService);
                int max = am.GetStreamMaxVolume(Stream.Music);
                
                am.SetStreamVolume(Stream.Music, max/2, 0);
            }
            mp.Start();
        }

        public static void ResumeMusic()
        {
            mp.Start();
        }

        public static void PauseMusic()
        {
            mp.Pause();
        }
        public static void StopMusic()
        {
            mp.Stop();
            MainActivity.hasMusicStarted = false;
        }

        public static void changeVolume(int x)
        {
            am.SetStreamVolume(Stream.Music, x, 0);
        }
    }
}