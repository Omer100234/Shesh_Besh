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
using Android.Graphics;

namespace Shesh_Besh
{
    class Stone
    {
        private Color color;
        private int posX;
        private int posY;
        public Stone(Color c, int posX, int posY)
        {
            this.color = c;
            this.posX = posX;
            this.posY = posY;
        }

        public Color GetColor()
        {
            return this.color;
        }

        public int getPosX()
        {
            return this.posX;
        }
        public int getPosY()
        {
            return this.posY;
        }

        public void setPosX(int x)
        {
            this.posX = x;

        }

        public void setPosY(int y)
        {
            this.posY = y;
        }

        public void drawStone(Canvas canvas, Paint p)
        {
            p.Color = this.color;
            canvas.DrawCircle(posX, posY, 20, p);
        }

    }
}