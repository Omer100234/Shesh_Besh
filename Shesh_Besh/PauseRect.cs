using Android.App;
using Android.Content;
using Android.Graphics;
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
    class PauseRect : Rectangle
    {
        AlertDialog dialog;
        public PauseRect(int r, int t, int l, int b,Context c) : base (r,t,l,b,c)
        {
            
        }
        public void activate(Context c)
        {
            this.c = c;

            AlertDialog.Builder builder = new AlertDialog.Builder(c);
            builder.SetMessage("continue?");
            builder.SetCancelable(false);
            builder.SetPositiveButton("yes", okAction);
            builder.SetNegativeButton("no", nokAction);
            this.dialog = builder.Create();
            this.dialog.Show();
        }

        private void nokAction(object sender, DialogClickEventArgs e)
        {
            
            Intent intent = new Intent(this.c, typeof(MainActivity));
            ((Activity)this.c).StartActivityForResult(intent, 0);

        }

        private void okAction(object sender, DialogClickEventArgs e)
        {
            this.dialog.Dismiss();

        }
        public override void DrawRectangle(Canvas canvas, Paint p)
        {
            base.DrawRectangle(canvas, p);
        }
    }
}