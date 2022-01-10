using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shesh_Besh
{
    class RollRect : Rectangle
    {
        MediaPlayer mp;
        
        public RollRect(int l, int t, int r, int b, Context c) : base(l, t, r, b, c)
        {
            mp = MediaPlayer.Create(this.c, Resource.Raw.dice);
            

        }
        public int[] activate(Context c)
        {
            Random rnd = new Random();
            int[] arr = new int[2];
            arr[0] = rnd.Next(6) + 1;
            arr[1] = rnd.Next(6) + 1;
            mp.Start();
            return arr;
            
        }
        public override void DrawRectangle(Canvas canvas, Paint p)
        {
            base.DrawRectangle(canvas, p);
            int xstart = left;
            int ystart = top;
            int xend = right;
            int yend = bottom;
            int dx = xend - xstart;
            int dy = yend - ystart;
            int r = dx / 4 - 8;
            p.Color = Color.Black;
            canvas.DrawCircle((float)xstart + dx * 3 / 4, (float)ystart + dy / 4, r, p);
            canvas.DrawCircle((float)xstart + dx / 2, (float)ystart + dy / 2, r, p);
            canvas.DrawCircle((float)xstart + dx / 4, (float)ystart + dy * 3 / 4, r, p);
        }


    }
}