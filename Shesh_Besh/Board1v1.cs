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
        PauseRect r1Pause, r2Pause;
        RollRect r1Roll, r2Roll;
        int n1, n2;
        char turn;
        int theIndexOfTheChosenTriangle;
        Cell[] board;
        Rectangle[] myMenu;
        Stone[] stones;
        Cell blackPrison, whitePrison;
        // checks for one time used functions 
        bool isSet;
        bool didThePlayHappenInThisVeriationOfTheLoop;
        bool didUserChooseWhereToPlayFrom;
        bool areTheCubesThrown, isC1Played, isC2played;
        bool isBlackEaten, isWhiteEaten;


        public Board1v1(Context context, char igs, Color c1, Color c2) : base(context)
        {
            this.isWhiteEaten = false;
            this.isBlackEaten = false;
            this.theIndexOfTheChosenTriangle = 100;
            this.didUserChooseWhereToPlayFrom = false;
            this.isC1Played = false;
            this.isC2played = false;
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
            areTheCubesThrown = false;
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
            
                highlighter(canvas);
           
            drawBoard(canvas);
            drawMenu(canvas);
            drawStones(canvas);
            this.p.Color = Color.Black;
            checkNumsForPrint(canvas);
            

            Invalidate();
        }

        public void highlighter(Canvas canvas)
        {
            // white prison index will be 31
            if (theIndexOfTheChosenTriangle==31)
            {
                Point ptp1, ptp2, ptp3;
                ptp1 = new Point(canvas.Width, whitePrison.getP1().Y - 5);
                ptp2 = new Point(canvas.Width, whitePrison.getP2().Y + 5);
                ptp3 = new Point(whitePrison.getP3().X - 5, whitePrison.getP3().Y);
                drawTriangle(ptp1, ptp2, ptp3, canvas, Color.Green);
            }

            //black prison index will be 32
            // white prison index will be 31
            if (theIndexOfTheChosenTriangle == 32)
            {
                Point ptp1, ptp2, ptp3;
                ptp1 = new Point(0, whitePrison.getP1().Y - 5);
                ptp2 = new Point(0, whitePrison.getP2().Y + 5);
                ptp3 = new Point(whitePrison.getP3().X + 5, whitePrison.getP3().Y);
                drawTriangle(ptp1, ptp2, ptp3, canvas, Color.Aqua);
            }
            for (int i = 0; i < 24; i++)
            {
                if (i == theIndexOfTheChosenTriangle)
                {
                    Point ptp1, ptp2, ptp3;
                    if (i < 12)
                    {
                        ptp1 = new Point(0, board[i].getP1().Y - 5);
                        ptp2 = new Point(0, board[i].getP2().Y + 5);
                        ptp3 = new Point(board[i].getP3().X + 5, board[i].getP3().Y);

                    }
                    else
                    {
                        ptp1 = new Point(canvas.Width, board[i].getP1().Y - 5);
                        ptp2 = new Point(canvas.Width, board[i].getP2().Y + 5);
                        ptp3 = new Point(board[i].getP3().X - 5, board[i].getP3().Y);
                    }
                    drawTriangle(ptp1, ptp2, ptp3, canvas, Color.Aqua);

                }

            }
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
                    Point p1 = new Point(0, y);
                    Point p2 = new Point(0, y2);
                    int yMid = (y + y2) / 2;
                    Point p3 = new Point(x, yMid);
                    blackPrison = new Cell();
                    blackPrison.setCellY(yMid);
                    blackPrison.setPoints(p1, p2, p3);
                    blackPrison.setMinHeight(25);
                    blackPrison.setRol('l');

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
                    Point p1 = new Point(canvas.Width, y);
                    Point p2 = new Point(canvas.Width, y2);
                    int yMid = (y + y2) / 2;
                    Point p3 = new Point(x, yMid);
                    whitePrison = new Cell();
                    whitePrison.setCellY(yMid);
                    whitePrison.setPoints(p1, p2, p3);
                    whitePrison.setMinHeight(canvas.Width - 25);
                    whitePrison.setRol('r');
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
            
            if (this.turn == 'w' && !areTheCubesThrown)
            {

                canvas.DrawRect(38, 1258, 106, 1328, p);
            }
            else if(this.turn == 'b' && !areTheCubesThrown)
            {

                canvas.DrawRect(614, 12, 682, 77, p);
            }
            this.p.SetStyle(Paint.Style.Fill);
            this.p.StrokeWidth = 1;

            

        }
        private void drawBoard(Canvas canvas)
        {

            for (int i = 0; i < 24; i++)
            {
                drawTriangle(board[i].getP1(), board[i].getP2(), board[i].getP3(), canvas, board[i].getColor());
            }
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


        public int theIndexAfterTheMoveWithCube(int index, int counter, char c)
        {
            if (c=='w')
            {
                for(int i =counter; i>0; i--)
                {
                    if (index==11 && counter>0)
                    {
                        return -1;
                    }
                    if(index>12)
                    {
                        index--;
                    }
                    else if(index == 12)
                    {
                        index = 0;
                    }
                    else if(index<12)
                    {
                        index++;
                    }
                }
            }
            else
            {
                for (int i = counter; i > 0; i--)
                {
                    if (index == 23 && counter > 0)
                    {
                        return -1;
                    }
                    if (index >= 12)
                    {
                        index++;
                    }
                    else if (index == 0)
                    {
                        index = 12;
                    }
                    else if (index < 12)
                    {
                        index--;
                    }
                }
            }
            return index;
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            didThePlayHappenInThisVeriationOfTheLoop = false;
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

            // start of check for white turn ----------------------------------------------------------------

            if (this.turn == 'w' && !areTheCubesThrown && !didUserChooseWhereToPlayFrom && !didThePlayHappenInThisVeriationOfTheLoop)
            {
                if (r1Roll.didUserTouchMe((int)e.GetX(), (int)e.GetY()))
                {
                    int[] arr = r1Roll.activate(this.context);
                    this.n1 = arr[0];
                    this.n2 = arr[1];
                    areTheCubesThrown = true;
                    didThePlayHappenInThisVeriationOfTheLoop = true;
                }
               

            }
            if (!isWhiteEaten && this.turn == 'w')
            {
                if (this.turn == 'w' && areTheCubesThrown && !didUserChooseWhereToPlayFrom && !didThePlayHappenInThisVeriationOfTheLoop)
                {
                    for (int i = 0; i < 24; i++)
                    {
                        if (board[i].didUserTouchMe((int)e.GetX(), (int)e.GetY()) && board[i].getState() == 'w' && e.Action == MotionEventActions.Down)
                        {
                            theIndexOfTheChosenTriangle = i;
                            didUserChooseWhereToPlayFrom = true;
                            didThePlayHappenInThisVeriationOfTheLoop = true;
                        }
                    }


                }

                if (this.turn == 'w' && didUserChooseWhereToPlayFrom && !didThePlayHappenInThisVeriationOfTheLoop)
                {
                    for (int i = 0; i < 24; i++)
                    {
                        if (board[i].didUserTouchMe((int)e.GetX(), (int)e.GetY()))
                        {
                            if (i == theIndexOfTheChosenTriangle && !didThePlayHappenInThisVeriationOfTheLoop && e.Action == MotionEventActions.Down)
                            {
                                didUserChooseWhereToPlayFrom = false;
                                theIndexOfTheChosenTriangle = 100;
                                didThePlayHappenInThisVeriationOfTheLoop = true;
                            }
                            else if (i == theIndexAfterTheMoveWithCube(theIndexOfTheChosenTriangle, n1, this.turn) && !isC1Played)
                            {
                                if (board[i].getState() == 'e' || board[i].getState() == 'w' || (board[i].getState() == 'b' && board[i].getStack().Count == 1))
                                {
                                    if (board[i].getState() == 'b' && board[i].getStack().Count == 1)
                                    {
                                        blackPrison.addStone(board[i].pullStone());
                                        isBlackEaten = true;
                                    }
                                    board[i].addStone(board[theIndexOfTheChosenTriangle].pullStone());
                                    isC1Played = true;
                                    didUserChooseWhereToPlayFrom = false;
                                    theIndexOfTheChosenTriangle = 100;
                                    if (isC1Played && isC2played)
                                    {
                                        isC1Played = false;
                                        isC2played = false;

                                        this.turn = 'b';
                                        theIndexOfTheChosenTriangle = 100;
                                        didUserChooseWhereToPlayFrom = false;
                                        areTheCubesThrown = false;
                                    }
                                }

                            }
                            else if (i == theIndexAfterTheMoveWithCube(theIndexOfTheChosenTriangle, n2, this.turn) && !isC2played)
                            {
                                if (board[i].getState() == 'e' || board[i].getState() == 'w' || (board[i].getState() == 'b' && board[i].getStack().Count == 1))
                                {
                                    if (board[i].getState() == 'b' && board[i].getStack().Count == 1)
                                    {
                                        blackPrison.addStone(board[i].pullStone());
                                        isBlackEaten = true;
                                    }
                                    board[i].addStone(board[theIndexOfTheChosenTriangle].pullStone());
                                    isC2played = true;
                                    didUserChooseWhereToPlayFrom = false;
                                    theIndexOfTheChosenTriangle = 100;
                                    if (isC1Played && isC2played)
                                    {
                                        isC1Played = false;
                                        isC2played = false;

                                        this.turn = 'b';
                                        theIndexOfTheChosenTriangle = 100;
                                        didUserChooseWhereToPlayFrom = false;
                                        areTheCubesThrown = false;
                                    }
                                }


                            }


                        }
                    }
                }
            }
                if (isWhiteEaten && this.turn == 'w' && !didThePlayHappenInThisVeriationOfTheLoop)
                {
                    if (whitePrison.didUserTouchMe((int)e.GetX(), (int)e.GetY()) && !didUserChooseWhereToPlayFrom)
                    {
                        
                        didUserChooseWhereToPlayFrom = true;
                        didThePlayHappenInThisVeriationOfTheLoop = true;
                        
                        theIndexOfTheChosenTriangle = 31;
                        if (theIndexOfTheChosenTriangle ==31)
                        {
                            Toast.MakeText(this.context, "it is 31", ToastLength.Short).Show();
                        }
                    }
                    if(didUserChooseWhereToPlayFrom && !didThePlayHappenInThisVeriationOfTheLoop)
                    {
                        for (int i=18;i<24;i++)
                        {
                            if (board[i].didUserTouchMe((int)e.GetX(), (int)e.GetY()))
                            {
                                if (board[i].getState() == 'e' || board[i].getState() == 'w' || (board[i].getState() == 'b' && board[i].getStack().Count == 1))
                                {
                                    if (i == 24 - n1 && !isC1Played)
                                    {
                                        if (board[i].getState() == 'b' && board[i].getStack().Count == 1)
                                        {
                                            blackPrison.addStone(board[i].pullStone());
                                            isBlackEaten = true;
                                        }
                                        board[i].addStone(whitePrison.pullStone());
                                        isC1Played = true;
                                        didUserChooseWhereToPlayFrom = false;
                                        theIndexOfTheChosenTriangle = 100;
                                        if (isC1Played && isC2played)
                                        {
                                            isC1Played = false;
                                            isC2played = false;

                                            this.turn = 'b';
                                            theIndexOfTheChosenTriangle = 100;
                                            didUserChooseWhereToPlayFrom = false;
                                            areTheCubesThrown = false;
                                        }
                                        if (whitePrison.getStack().Count == 0)
                                        {
                                            isWhiteEaten = false;
                                        }
                                    }
                                    if (i == 24 - n2 && !isC1Played)
                                    {
                                        if (board[i].getState() == 'b' && board[i].getStack().Count == 1)
                                        {
                                            blackPrison.addStone(board[i].pullStone());
                                            isBlackEaten = true;
                                        }
                                        board[i].addStone(whitePrison.pullStone());
                                        isC2played = true;
                                        didUserChooseWhereToPlayFrom = false;
                                        theIndexOfTheChosenTriangle = 100;
                                        if (isC1Played && isC2played)
                                        {
                                            isC1Played = false;
                                            isC2played = false;

                                            this.turn = 'b';
                                            theIndexOfTheChosenTriangle = 100;
                                            didUserChooseWhereToPlayFrom = false;
                                            areTheCubesThrown = false;
                                        }
                                        if (whitePrison.getStack().Count == 0)
                                        {
                                            isWhiteEaten = false;
                                        }
                                    }
                                }
                            
                            }
                        }
                    }
                }

            

            // end of the check for the white turn ----------------------------------------------------------------------
            //start of the check of the black turn ----------------------------------------------------------------------

            if (this.turn == 'b' && !areTheCubesThrown && !didUserChooseWhereToPlayFrom && !didThePlayHappenInThisVeriationOfTheLoop)
            {
                if (r2Roll.didUserTouchMe((int)e.GetX(), (int)e.GetY()))
                {
                    int[] arr = r1Roll.activate(this.context);
                    this.n1 = arr[0];
                    this.n2 = arr[1];
                    areTheCubesThrown = true;
                    didThePlayHappenInThisVeriationOfTheLoop = true;
                }


            }
            
            if (this.turn == 'b' && areTheCubesThrown && !didUserChooseWhereToPlayFrom && !didThePlayHappenInThisVeriationOfTheLoop)
            {
                for (int i = 0; i < 24; i++)
                {
                    if (board[i].didUserTouchMe((int)e.GetX(), (int)e.GetY()) && board[i].getState() == 'b' && e.Action == MotionEventActions.Down)
                    {
                        theIndexOfTheChosenTriangle = i;
                        didUserChooseWhereToPlayFrom = true;
                        didThePlayHappenInThisVeriationOfTheLoop = true;
                    }
                }


            }

            if (this.turn == 'b' && didUserChooseWhereToPlayFrom)
            {
                for (int i = 0; i < 24; i++)
                {
                    if (board[i].didUserTouchMe((int)e.GetX(), (int)e.GetY()))
                    {
                        if (i == theIndexOfTheChosenTriangle && !didThePlayHappenInThisVeriationOfTheLoop && e.Action == MotionEventActions.Down)
                        {
                            didUserChooseWhereToPlayFrom = false;
                            theIndexOfTheChosenTriangle = 100;
                            didThePlayHappenInThisVeriationOfTheLoop = true;
                        }
                        else if (i == theIndexAfterTheMoveWithCube(theIndexOfTheChosenTriangle, n1, this.turn)  && !isC1Played)
                        {
                            if (board[i].getState() == 'e' || board[i].getState() == 'b' || (board[i].getState() == 'w' && board[i].getStack().Count == 1))
                            {
                                if (board[i].getState() == 'w' && board[i].getStack().Count == 1)
                                {
                                    whitePrison.addStone(board[i].pullStone());
                                    isWhiteEaten = true;
                                }
                                board[i].addStone(board[theIndexOfTheChosenTriangle].pullStone());
                                isC1Played = true;
                                didUserChooseWhereToPlayFrom = false;
                                theIndexOfTheChosenTriangle = 100;
                                if (isC1Played && isC2played)
                                {
                                    isC1Played = false;
                                    isC2played = false;

                                    this.turn = 'w';
                                    theIndexOfTheChosenTriangle = 100;
                                    didUserChooseWhereToPlayFrom = false;
                                    areTheCubesThrown = false;
                                }
                            }
                        }
                        else if (i == theIndexAfterTheMoveWithCube(theIndexOfTheChosenTriangle, n2, this.turn) && !isC2played)
                        {
                            if (board[i].getState() == 'e' || board[i].getState() == 'b' || (board[i].getState() == 'w' && board[i].getStack().Count == 1))
                            {
                                if (board[i].getState() == 'w' && board[i].getStack().Count == 1)
                                {
                                    whitePrison.addStone(board[i].pullStone());
                                    isWhiteEaten = true;
                                }
                                board[i].addStone(board[theIndexOfTheChosenTriangle].pullStone());
                                isC2played = true;
                                didUserChooseWhereToPlayFrom = false;
                                theIndexOfTheChosenTriangle = 100;
                                if (isC1Played && isC2played)
                                {
                                    isC1Played = false;
                                    isC2played = false;

                                    this.turn = 'w';
                                    theIndexOfTheChosenTriangle = 100;
                                    didUserChooseWhereToPlayFrom = false;
                                    areTheCubesThrown = false;
                                }
                            }
                        }


                    }
                }
            }
            
            // end of the check of the black turn-----------------------------------------------------------

            return true;
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