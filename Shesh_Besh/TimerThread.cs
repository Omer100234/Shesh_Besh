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
using System.Threading;

namespace Shesh_Besh
{
    class MyTimer
    {
        public int counter;
        Handler handler;
        ThreadStart threadstart;
        Thread t;
        bool stop;


        public MyTimer(Handler handler, int counter)
        {
            this.counter = counter;
            this.handler = handler;
            stop = false;
        }
        public void Begin()
        {
            ThreadStart threadstart = new ThreadStart(Run);
            Thread t = new Thread(threadstart);
            
            t.Start();

        }

        public void Stop()
        {
            this.stop = true;
            /*t.Abort();*/

        }

        private void Run()
        {
            while (!this.stop)
            {
           
                    this.counter++;
                    Thread.Sleep(1000);
                    Message msg = new Message();
                    msg.Arg1 = this.counter;
                    handler.SendMessage(msg);
                

            }
        }
    }
}