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
    class PulloutRect : Rectangle
    {
        Cell whiteWinningCell;
        Cell blackWinningCell;
        public PulloutRect(int l, int t, int r, int b, Context c) : base(l, t, r, b, c)
        {
            whiteWinningCell = new Cell();
            blackWinningCell = new Cell();
            whiteWinningCell.setCellY(-3000);
            blackWinningCell.setCellY(-3000);


        }

        public char getWinner()
        {
            if(whiteWinningCell.getStack().Count==15)
            {
                return 'W';
            }
            if (blackWinningCell.getStack().Count==15)
            {
                return 'B';
            }
            return 'N';
        }
        public char activate(Cell[] arr, int index, char turn)
        {
            if (turn == 'w')
            {
                whiteWinningCell.addStone(arr[index].pullStone());
                if(whiteWinningCell.getStack().Count == 15)
                {
                    return 'W';
                }
            }
            if (turn == 'b')
            {
                blackWinningCell.addStone(arr[index].pullStone());
                if (blackWinningCell.getStack().Count == 15)
                {
                    return 'B';
                }
            }
            return 'N';

        }
        public override void DrawRectangle(Canvas canvas, Paint p)
        {
            base.DrawRectangle(canvas, p);
        }
    }
}