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
        static MediaPlayer mp; // media player which plays the music
        MusicPlayerBroadcastReciever musicPlayerBroadcast; // broadcast reciever, is registered with the media player an plays the music according to the user

        public static bool musicStopped = false;
        public override void OnCreate()
        {
            base.OnCreate();

            mp = MediaPlayer.Create(this, Resource.Raw.song);
            musicPlayerBroadcast = new MusicPlayerBroadcastReciever(mp);

            IntentFilter intentFilter = new IntentFilter("music");
            RegisterReceiver(musicPlayerBroadcast, intentFilter);
        }
        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            Intent i = new Intent("music");
            i.PutExtra("action", 1);
            SendBroadcast(i);


            // thread which stops the service if music is stopped for a long time, user left the app
            Thread t = new Thread(RunUntilMusicStopped);
            t.Start();

            return base.OnStartCommand(intent, flags, startId);
        }

        public static void setVolume(float f)
        {
            mp.SetVolume(f/100, f/100);
        }
        private void RunUntilMusicStopped()
        {
            while (!musicStopped) ;
            StopSelf();
        }

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }
    }
}