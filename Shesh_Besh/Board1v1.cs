﻿using System;
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
        PauseRect r1Pause, r2Pause;
        RollRect r1Roll, r2Roll;
        int n1, n2;
        char turn;
        Cell[] board;
        Rectangle[] myMenu;
        Stone[] stones;
        // checks for one time used functions 
        bool isSet;


        public Board1v1(Context context, char igs, Color c1, Color c2) : base(context)
        {
            this.isSet = false;
            this.board = new Cell[24];
            for (int i = 0; i < 24; i++)
            {
                this.board[i] = new Cell();
            }
            this.context = context;
            this.r = 30;
            this.isGameSaved = igs;
            this.p = new Paint();
            this.c1 = c1;
            this.c2 = c2;
            sc1 = Color.White;
            sc2 = Color.Black;
            this.r1Pause = new PauseRect(616, 1260, 680, 1326, this.context);
            this.r2Pause = new PauseRect(40, 14, 104, 75, this.context);
            this.r1Roll = new RollRect(40, 1260, 104, 1326, this.context);
            this.r2Roll = new RollRect(616, 14, 680, 75, this.context);
            myMenu = new Rectangle[4];
            myMenu[0] = r1Pause;
            myMenu[1] = r2Pause;
            myMenu[2] = r1Roll;
            myMenu[3] = r2Roll;
            this.p.TextSize = 50;
            this.turn = 'w';
            this.stones = new Stone[30];
            


        }
        protected override void OnDraw(Canvas canvas)
        {
            
            if (!this.isSet)
            {
                setHeights(canvas);
                distribute();
                this.isSet = true;
            }
            this.p.Color = Color.BurlyWood;
            canvas.DrawRect(0, 0, canvas.Width, canvas.Height, this.p);
            
            drawBoard(canvas);
            drawMenu(canvas);
            drawStones(canvas);
            this.p.Color = Color.Black;
            checkNumsForPrint(canvas);
            

            Invalidate();
        }

        private void drawStones(Canvas canvas)
        {
            for(int i=0;i<stones.Length;i++)
            {
                stones[i].drawStone(canvas, this.p);
            }
        }

        private void setHeights(Canvas canvas)
        {

            int alt = 2;
            int y = 0;
            int y2 = canvas.Height / 15;
            int x = 3 * canvas.Width / 7;
            for (int i = 0; i < 14; i++)
            {

                
                if (i != 0 && i < 7)
                {
                    if (alt == 2)
                    {
                        int yMid = (y + y2) / 2;
                        //drawTriangle(0, y, 0, y2, x, yMid, canvas, this.c1);
                        Point p1 = new Point(0, y);
                        Point p2 = new Point(0, y2);
                        Point p3 = new Point(x, yMid);
                        this.board[i - 1].setCellY(yMid);
                        this.board[i - 1].setPoints(p1, p2, p3);
                        this.board[i - 1].setColor(this.c1);
                        this.board[i - 1].setMinHeight(25);
                        this.board[i - 1].setRol('l');
                        

                    }
                    else
                    {
                        int yMid = (y + y2) / 2;
                        //drawTriangle(0, y, 0, y2, x, yMid, canvas, this.c2);
                        Point p1 = new Point(0, y);
                        Point p2 = new Point(0, y2);
                        Point p3 = new Point(x, yMid);
                        this.board[i - 1].setCellY(yMid);
                        this.board[i - 1].setPoints(p1, p2, p3);
                        this.board[i - 1].setColor(this.c2);
                        this.board[i - 1].setMinHeight(25);
                        this.board[i - 1].setRol('l');

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
                        
                        Point p1 = new Point(0, y);
                        Point p2 = new Point(0, y2);
                        Point p3 = new Point(x, yMid);
                        this.board[i - 2].setCellY(yMid);
                        this.board[i - 2].setPoints(p1, p2, p3);
                        this.board[i - 2].setColor(this.c2);
                        this.board[i - 2].setMinHeight(25);
                        this.board[i - 2].setRol('l');


                    }
                    else
                    {
                        int yMid = (y + y2) / 2;
                        

                        Point p1 = new Point(0, y);
                        Point p2 = new Point(0, y2);
                        Point p3 = new Point(x, yMid);
                        this.board[i - 2].setCellY(yMid);
                        this.board[i - 2].setPoints(p1, p2, p3);
                        this.board[i - 2].setColor(this.c1);
                        this.board[i - 2].setMinHeight(25);
                        this.board[i - 2].setRol('l');
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

                if (i != 0 && i < 7)
                {
                    if (alt == 2)
                    {
                        int yMid = (y + y2) / 2;
                        
                        Point p1 = new Point(canvas.Width, y);
                        Point p2 = new Point(canvas.Width, y2);
                        Point p3 = new Point(x, yMid);
                        this.board[i +11].setCellY(yMid);
                        this.board[i +11].setPoints(p1, p2, p3);
                        this.board[i +11].setColor(this.c2);
                        this.board[i +11].setMinHeight(canvas.Width - 25);
                        this.board[i +11].setRol('r');

                    }
                    else
                    {
                        int yMid = (y + y2) / 2;
                        
                        Point p1 = new Point(canvas.Width, y);
                        Point p2 = new Point(canvas.Width, y2);
                        Point p3 = new Point(x, yMid);
                        this.board[i + 11].setCellY(yMid);
                        this.board[i + 11].setPoints(p1, p2, p3);
                        this.board[i +11].setColor(this.c1);
                        this.board[i + 11].setMinHeight(canvas.Width - 25);
                        this.board[i + 11].setRol('r');
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
                        
                        Point p1 = new Point(canvas.Width, y);
                        Point p2 = new Point(canvas.Width, y2);
                        Point p3 = new Point(x, yMid);
                        this.board[i + 10].setCellY(yMid);
                        this.board[i + 10].setPoints(p1, p2, p3);
                        this.board[i +10 ].setColor(this.c1);
                        this.board[i + 10].setMinHeight(canvas.Width - 25);
                        this.board[i + 10].setRol('r');

                    }
                    else
                    {
                        int yMid = (y + y2) / 2;
                        

                        Point p1 = new Point(canvas.Width, y);
                        Point p2 = new Point(canvas.Width, y2);
                        Point p3 = new Point(x, yMid);
                        this.board[i + 10].setCellY(yMid);
                        this.board[i + 10].setPoints(p1, p2, p3);
                        this.board[i +10].setColor(this.c2);
                        this.board[i + 10].setMinHeight(canvas.Width - 25);
                        this.board[i + 10].setRol('r');
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

        private void distribute()
        {
            for (int i = 0; i < 30;i++)
            {
                if(i<15)
                {
                    stones[i] = new Stone(Color.Aqua, 0, 0);
                }
                else
                {
                    stones[i] = new Stone(Color.Orange, 0, 0);
                }
            }
            int counter = 0;
            for(int i=0;i<5;i++)
            {
                board[6].addStone(stones[counter]);
                counter++;
            }
            for (int i = 0; i < 3; i++)
            {
                board[4].addStone(stones[counter]);
                counter++;
            }
            for (int i = 0; i < 5; i++)
            {
                board[12].addStone(stones[counter]);
                counter++;
            }
            for (int i = 0; i < 2; i++)
            {
                board[23].addStone(stones[counter]);
                counter++;
            }
            for (int i = 0; i < 5; i++)
            {
                board[0].addStone(stones[counter]);
                counter++;
            }
            for (int i = 0; i < 2; i++)
            {
                board[11].addStone(stones[counter]);
                counter++;
            }
            for (int i = 0; i < 3; i++)
            {
                board[16].addStone(stones[counter]);
                counter++;
            }
            for (int i = 0; i < 5; i++)
            {
                board[18].addStone(stones[counter]);
                counter++;
            }
        }

        private void drawMenu(Canvas canvas)
        {
            

            for (int i=0;i<4;i++)
            {
                this.p.Color = Color.Gray;
                myMenu[i].DrawRectangle(canvas, this.p);
;           }
            this.p.Color = Color.Black;
            this.p.StrokeWidth = 5;
            canvas.DrawLine(0, canvas.Height * 1 / 15, canvas.Width, canvas.Height * 1 / 15, p);
            canvas.DrawLine(0, canvas.Height * 7 / 15, canvas.Width, canvas.Height * 7 / 15, p);
            canvas.DrawLine(0, canvas.Height * 8 / 15, canvas.Width, canvas.Height * 8 / 15, p);
            canvas.DrawLine(0, canvas.Height * 14 / 15, canvas.Width, canvas.Height * 14 / 15, p);



            this.p.SetStyle(Paint.Style.Stroke);
            
            if (this.turn == 'w')
            {

                canvas.DrawRect(38, 1258, 106, 1328, p);
            }
            else
            {

                canvas.DrawRect(614, 12, 682, 77, p);
            }
            this.p.SetStyle(Paint.Style.Fill);
            this.p.StrokeWidth = 1;

            

        }
        private void drawBoard(Canvas canvas)
        {

            for (int i=0;i<24;i++)
            {
                drawTriangle(board[i].getP1(), board[i].getP2(), board[i].getP3(), canvas, board[i].getColor());
            }





            /*int alt = 2;
            int y = 0;
            int y2 = canvas.Height / 15;
            int x = 3 * canvas.Width / 7;
            for (int i = 0; i < 14; i++)
            {


                if (i != 0 && i < 7)
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

                if (i != 0 && i < 7)
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
            canvas.DrawLine(0, canvas.Height / 15, canvas.Width, canvas.Height / 15, p);*/
        }

        private void drawTriangle(Point pa, Point pb, Point pc, Canvas canvas, Color c)
        {

            Point p1 = pa;
            Point p2 = pb;
            Point p3 = pc;





            Path path = new Path();
            path.SetFillType(Path.FillType.EvenOdd);
            path.MoveTo(p1.X, p1.Y);
            path.LineTo(p2.X, p2.Y);
            path.LineTo(p3.X, p3.Y);
            path.Close();
            this.p.Color = c;
            canvas.DrawPath(path, this.p);
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            if (MotionEventActions.Down == e.Action)
            {
                if (r1Pause.didUserTouchMe((int)e.GetX(), (int)e.GetY()))
                {
                    this.r1Pause.activate(this.context);
                }
                if (r2Pause.didUserTouchMe((int)e.GetX(), (int)e.GetY()))
                {
                    this.r2Pause.activate(this.context);
                }
            }
            if (this.turn == 'w')
            {
                if (r1Roll.didUserTouchMe((int)e.GetX(), (int)e.GetY()))
                {
                    int[] arr = r1Roll.activate(this.context);
                    this.n1 = arr[0];
                    this.n2 = arr[1];
                    this.turn = 'b';
                }


            }
            else if (this.turn == 'b')
            {
                if (r2Roll.didUserTouchMe((int)e.GetX(), (int)e.GetY()))
                {
                    int[] arr = r2Roll.activate(this.context);
                    this.n1 = arr[0];
                    this.n2 = arr[1];
                    this.turn = 'w';
                }

            }

            return true;
        }

        private void drawmark(Canvas c)
        {

        }

        public void checkNumsForPrint(Canvas c)
        {

            if (n1 != 0)
            {
                c.DrawText("" + this.n1, 300, 300, this.p);
                c.DrawText("" + this.n2, 300, 800, this.p);
            }

        }


    }
}