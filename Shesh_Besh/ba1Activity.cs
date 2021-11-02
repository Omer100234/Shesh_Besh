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

namespace Shesh_Besh
{
    [Activity(Label = "ba1Activity")]
    public class ba1Activity : Activity
    {
        BoardAI ba1;
        FrameLayout fl1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ba1Layout);
            ba1 = new BoardAI(this, 'n', Android.Graphics.Color.Red, Android.Graphics.Color.Black);
            
            fl1 = (FrameLayout)FindViewById(Resource.Id.fl1);
            fl1.AddView(ba1);

        }
    }
}