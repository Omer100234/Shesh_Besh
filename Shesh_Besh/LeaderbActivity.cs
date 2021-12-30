using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Shesh_Besh
{
    [Activity(Label = "LeaderbActivity")]
    public class LeaderbActivity : Activity
    {
        TextView tv1, tv2;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Leaderboards);
            // Create your application here
            tv1 = (TextView)FindViewById(Resource.Id.tv1);
            tv1.TextSize = 20;
            tv1.SetTextColor(Color.Orange);
            tv2 = (TextView)FindViewById(Resource.Id.tv2);
            tv2.TextSize = 20;
            tv2.SetTextColor(Color.Orange);
            tv1.Text = "white has won: " + MainActivity.totals.GetInt("ww", 0) + "/" + MainActivity.totals.GetInt("gp", 0);
            tv2.Text = "black has won: " + MainActivity.totals.GetInt("bw", 0) + "/" + MainActivity.totals.GetInt("gp", 0);
        }
    }
}