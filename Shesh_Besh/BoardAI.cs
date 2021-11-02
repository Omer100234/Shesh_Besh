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
    class BoardAI : View
    {
        
        Context context;
        Paint p;
        int r;
        char isGameSaved;
        Color c1, c2, sc1, sc2;

        public BoardAI(Context context, char igs, Color c1, Color c2) : base(context)
        {
            this.context = context;
            this.r = 30;
            this.isGameSaved = igs;
            this.p = new Paint();
            this.c1 = c1;
            this.c2 = c2;
            sc1 = Color.White;
            sc2 = Color.Black;
        }
        protected override void OnDraw(Canvas canvas)
        {
            this.p.Color = Color.BurlyWood;
            canvas.DrawRect(0, 0, canvas.Width, canvas.Height, this.p);
            drawBoard(canvas);
            drawMenu(canvas);

            Invalidate();
        }

        private void drawMenu(Canvas canvas)
        {

            int xstart = canvas.Width * 4 / 5 + 40;
            int ystart = canvas.Height * 13 / 14 + 3;
            int xend = canvas.Width - 40;
            int yend = canvas.Height - 7;
            this.p.Color = Color.Gray;
            canvas.DrawRect(xstart, ystart, xend, yend, this.p);

            xstart += 20;
            ystart += 20;
            xend -= 20;
            yend -= canvas.Height / 28;
            yend -= 10;
            this.p.Color = Color.Black;
            canvas.DrawRect(xstart, ystart, xend, yend, this.p);

            xstart = canvas.Width * 4 / 5 + 40;
            ystart = canvas.Height * 13 / 14 + 3;
            xend = canvas.Width - 40;
            yend = canvas.Height - 7;

            xstart += 20;
            ystart += 10 + canvas.Height / 28;
            xend -= 20;
            yend -= 20;
            this.p.Color = Color.Black;
            canvas.DrawRect(xstart, ystart, xend, yend, this.p);

            xstart = 40;
            ystart = canvas.Height * 13 / 14 + 3;
            xend = canvas.Width / 5 -40;
            yend = canvas.Height - 7;
            this.p.Color = Color.Gray;
            canvas.DrawRect(xstart, ystart, xend, yend, this.p);
        }
        private void drawBoard(Canvas canvas)
        {
            int alt = 2;
            int y = 0;
            int y2 = canvas.Height / 14;
            int x = 3 * canvas.Width / 7;
            for ( int i=0;i<13;i++)
            {
                
                if (i<6)
                {
                    if (alt==2)
                    {
                        int yMid = (y + y2) / 2;
                        drawTriangle(0, y, 0, y2, x, yMid, canvas, this.c1);
                        
                        
                    }
                    else
                    {
                        int yMid = (y + y2) / 2;
                        drawTriangle(0, y, 0, y2, x, yMid, canvas, this.c2);
                        

                    }

                    
                }
                if (i == 6)
                {
                    this.p.Color = Color.Black;
                    canvas.DrawLine(0, y, canvas.Width / 2, y, this.p);
                    canvas.DrawLine(0, y2, canvas.Width / 2, y2, this.p);
                }
                if (i > 6)
                {
                    if (alt == 2)
                    {
                        int yMid = (y + y2) / 2;
                        drawTriangle(0, y, 0, y2, x, yMid, canvas, this.c2);


                    }
                    else
                    {
                        int yMid = (y + y2) / 2;
                        drawTriangle(0, y, 0, y2, x, yMid, canvas, this.c1);


                    }


                }
                alt = 2 / alt;
                y += canvas.Height / 14;
                y2 += canvas.Height / 14;
            }




            y = 0;
            y2 = canvas.Height / 14;
            x = 4 * canvas.Width / 7;
            alt = 2;
            for (int i = 0; i < 13; i++)
            {

                if (i <6)
                {
                    if (alt == 2)
                    {
                        int yMid = (y + y2) / 2;
                        drawTriangle(canvas.Width, y, canvas.Width, y2, x, yMid, canvas, this.c2);


                    }
                    else
                    {
                        int yMid = (y + y2) / 2;
                        drawTriangle(canvas.Width, y, canvas.Width, y2, x, yMid, canvas, this.c1);


                    }


                }
                if (i==6)
                {
                    this.p.Color = Color.Black;
                    canvas.DrawLine(canvas.Width, y, canvas.Width / 2, y, this.p);
                    canvas.DrawLine(canvas.Width, y2, canvas.Width / 2, y2, this.p);
                }
                if (i > 6)
                {
                    if (alt == 2)
                    {
                        int yMid = (y + y2) / 2;
                        drawTriangle(canvas.Width, y, canvas.Width, y2, x, yMid, canvas, this.c1);


                    }
                    else
                    {
                        int yMid = (y + y2) / 2;
                        drawTriangle(canvas.Width, y, canvas.Width, y2, x, yMid, canvas, this.c2);


                    }


                }
                alt = 2 / alt;
                y += canvas.Height / 14;
                y2 += canvas.Height / 14;
            }
            this.p.Color = Color.Black;
            canvas.DrawLine(0, y, canvas.Width, y, p);
        }

        private void drawTriangle(int x, int y, int x2, int y2, int x3, int y3, Canvas canvas,Color c)
        {

            Point p1 = new Point(x, y);
            Point p2 = new Point(x2, y2);
            Point p3 = new Point(x3, y3);


            


            Path path = new Path();
            path.SetFillType(Path.FillType.EvenOdd);
            path.MoveTo(p1.X, p1.Y);
            path.LineTo(p2.X, p2.Y);
            path.LineTo(p3.X, p3.Y);
            path.Close();
            this.p.Color = c;
            canvas.DrawPath(path, this.p);
        }

    }

    
}