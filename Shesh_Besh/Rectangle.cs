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
    class Rectangle
    {
        protected Context c;
        protected int left;
        protected int top;
        protected int right;
        protected int bottom;
        public Rectangle(int left, int top, int right, int bottom, Context c)
        {
            this.left = left;
            this.top = top;
            this.right = right;
            this.bottom = bottom;
            this.c = c;
        }
        public int getLeft()
        {
            return this.left;
        }
        public int getTop()
        {
            return this.top;
        }
        public int getRight()
        {
            return this.right;
        }
        public int getbottom()
        {
            return this.bottom;
        }
        public void setLeft(int left)
        {
            this.left = left;
        }
        public void setTop(int top)
        {
            this.top = top;
        }
        public void setRight(int right)
        {
            this.right = right;
        }
        public void setBottom(int bottom)
        {
            this.bottom = bottom;
        }
        public bool didUserTouchMe(int x, int y)
        {
            if(this.right > x && this.left< x)
            {
                if(this.top <y && this.bottom > y)
                {
                    return true;

                }
            }
            return false;
        }

        public virtual void DrawRectangle(Canvas canvas, Paint p)
        {
            canvas.DrawRect(this.left, this.top, this.right, this.bottom, p);
        }
        
    }
}