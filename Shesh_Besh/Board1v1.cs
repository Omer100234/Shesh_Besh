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
using Android.Graphics;

namespace Shesh_Besh
{
    class Board1v1 : View
    {
        Context context;
        Paint p;
        int r;
        char isGameSaved;
        Color c1, c2, sc1, sc2;

        public Board1v1(Context context, char igs, Color c1, Color c2) : base(context)
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
            //right side

            int xstart = canvas.Width * 4 / 5 + 40;
            int ystart = canvas.Height * 14 / 15 + 14;
            int xend = canvas.Width - 40;
            int yend = canvas.Height - 10;
            this.p.Color = Color.Gray;
            canvas.DrawRect(xstart, ystart, xend, yend, this.p);

            xstart += 20;
            ystart += 10;
            xend -= 20;
            yend -= canvas.Height / 30;
            this.p.Color = Color.Black;
            canvas.DrawRect(xstart, ystart, xend, yend, this.p);

            xstart = canvas.Width * 4 / 5 + 40;
            ystart = canvas.Height * 14 / 15 + 14;
            xend = canvas.Width - 40;
            yend = canvas.Height - 10;

            xstart += 20;
            ystart += canvas.Height / 30;
            xend -= 20;
            yend -= 10;
            this.p.Color = Color.Black;
            canvas.DrawRect(xstart, ystart, xend, yend, this.p);
            
            xstart = 40;
            ystart = canvas.Height * 14 / 15 + 14;
            xend = canvas.Width / 5 - 40;
            yend = canvas.Height - 18;
            this.p.Color = Color.Gray;
            int dx = xend - xstart;
            int dy = yend - ystart;
            canvas.DrawRect(xstart, ystart, xend, yend, this.p);


            int r = dx / 4 - 8;
            this.p.Color = Color.Black;
            canvas.DrawCircle((float)xstart + dx * 3 / 4, (float)ystart + dy / 4, r, p);
            canvas.DrawCircle((float)xstart + dx / 2, (float)ystart + dy / 2, r, p);
            canvas.DrawCircle((float)xstart + dx / 4, (float)ystart + dy * 3 / 4, r, p);


            //left side

            xstart = 40;
            ystart = 14;
            xend = canvas.Width /5 - 40;
            yend = canvas.Height/ 15 - 14;
            this.p.Color = Color.Gray;
            canvas.DrawRect(xstart, ystart, xend, yend, this.p);

            xstart += 20;
            ystart += 10;
            xend -= 20;
            yend -= canvas.Height / 30;
            yend += 5;
            this.p.Color = Color.Black;
            canvas.DrawRect(xstart, ystart, xend, yend, this.p);
            
            xstart = 40;
            ystart = 14;
            xend = canvas.Width /5 - 40;
            yend = canvas.Height/ 15 - 14;

            xstart += 20;
            ystart += canvas.Height / 30;
            ystart -= 5;
            xend -= 20;
            yend -= 10;
            this.p.Color = Color.Black;
            canvas.DrawRect(xstart, ystart, xend, yend, this.p);
            
            xstart = canvas.Width * 4 / 5 + 40;
            ystart = 14;
            xend = canvas.Width - 40;
            yend = canvas.Height/ 15 - 14;
            this.p.Color = Color.Gray;
            
            dx = xend - xstart;

            dy = yend - ystart;
            canvas.DrawRect(xstart, ystart, xend, yend, this.p);
            

            r = dx / 4 - 8;
            this.p.Color = Color.Black;
            canvas.DrawCircle((float)xstart + dx * 3 / 4, (float)ystart + dy / 4, r, p);
            canvas.DrawCircle((float)xstart + dx / 2, (float)ystart + dy / 2, r, p);
            canvas.DrawCircle((float)xstart + dx / 4, (float)ystart + dy * 3 / 4, r, p); 

        }
        private void drawBoard(Canvas canvas)
        {
            int alt = 2;
            int y = 0;
            int y2 = canvas.Height / 15;
            int x = 3 * canvas.Width / 7;
            for (int i = 0; i < 14; i++)
            {
                
                
                if (i!=0 && i < 7)
                {
                    if (alt == 2)
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
                if (i == 7)
                {
                    this.p.Color = Color.Black;
                    canvas.DrawLine(0, y, canvas.Width / 2, y, this.p);
                    canvas.DrawLine(0, y2, canvas.Width / 2, y2, this.p);
                }
                if (i > 7)
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
                y += canvas.Height / 15;
                y2 += canvas.Height / 15;
            }




            y = 0;
            y2 = canvas.Height / 15;
            x = 4 * canvas.Width / 7;
            alt = 2;
            for (int i = 0; i < 14; i++)
            {

                if (i !=0 && i < 7)
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
                if (i == 7)
                {
                    this.p.Color = Color.Black;
                    canvas.DrawLine(canvas.Width, y, canvas.Width / 2, y, this.p);
                    canvas.DrawLine(canvas.Width, y2, canvas.Width / 2, y2, this.p);
                }
                if (i > 7)
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
                y += canvas.Height / 15;
                y2 += canvas.Height / 15;
            }
            this.p.Color = Color.Black;
            canvas.DrawLine(0, y, canvas.Width, y, p);
            canvas.DrawLine(0, canvas.Height / 15, canvas.Width, canvas.Height / 15, p);
        }

        private void drawTriangle(int x, int y, int x2, int y2, int x3, int y3, Canvas canvas, Color c)
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
