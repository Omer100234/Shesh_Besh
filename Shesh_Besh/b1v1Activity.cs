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
        

        Board1v1 b1v1;
        FrameLayout fl1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.b1v1Layout);
            b1v1 = new Board1v1(this, 'n', Android.Graphics.Color.Red, Android.Graphics.Color.Black);

            fl1 = (FrameLayout)FindViewById(Resource.Id.fl1);
            fl1.AddView(b1v1);

            
        }

        





    }
}