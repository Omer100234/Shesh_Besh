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
    class Cell
    {
        Stack<Stone> stack;
        int minheight;
        char state;
        int cellY;
        Point p1, p2, p3;
        Color c;
        char rol;
        public Cell()
        {
            this.stack = new Stack<Stone>( );
            this.state = 'e';
            minheight = 25;
        }

       

        public Stack<Stone> getStack()
        {
            return this.stack;
        }

        public void setCellY(int x)
        {
            this.cellY = x;
        }
         
        public void setRol(char c)
        {
            this.rol = c;
        }

        public Stone pullStone()
        {
            Stone s = this.stack.Pop();
            if (this.stack.Count == 0)
            {
                this.state = 'e';
            }
            if (this.rol == 'l')
            {
                this.minheight -= 50;
            }
            else
            {
                this.minheight += 50;
            }
            return s;
            
        }

        public void addStone(Stone s)
        {
            stack.Push(s);
            if (s.GetColor() == Color.Orange)
            {
                this.state = 'b';
            }
            else
            {
                this.state = 'w';
            }
            s.setPosX(minheight);
            s.setPosY(cellY);
            if (this.rol == 'l')
            {
                this.minheight += 50;
            }
            else
            {
                this.minheight -= 50;
            }
        }

        public char getState()
        {
            return this.state;
        }
        public void setMinHeight(int x)
        {
            this.minheight = x;

        }

        public int getMinHeight()
        {
            return this.minheight;
        }

        public void setPoints(Point p1, Point p2, Point p3)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
        }


        public Point getP1()
        {
            return this.p1;
        }

        public Point getP2()
        {
            return this.p2;
        }

        public Point getP3()
        {
            return this.p3;
        }

        public void setColor(Color c)
        {
            this.c = c;
        }

        public Color getColor()
        {
            return this.c;
        }
        public bool didUserTouchMe(int otherX, int otherY)
        {
            double m1 = (this.p1.Y - this.p3.Y) /  (double) (this.p1.X - this.p3.X);
            double m2 = (this.p2.Y - this.p3.Y) / (double) (this.p2.X - this.p3.X);
            bool isBelowp1p3 = otherY > m1 * otherX - m1 * this.p1.X + this.p1.Y;
            bool isAbovep2p3 = otherY < m2 * otherX - m2 * this.p2.X + this.p2.Y;
            
            if (isAbovep2p3 && isBelowp1p3)
            {
                return true;
            }
            return false;

        }


    }
}