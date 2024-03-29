﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.CompilerServices;

namespace DancingStar
{
    class DancingStar
    {
        public DancingStar(int X, int Y)
        {
            x = X;
            y = Y;
        }
        private int _x;
        private int _y;
        public int x
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }
        public int y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }
        public void goUp()
        {
            if (y > 0)
            {
                y = y - 1;
            }
            else
            {
                y = y + 1;
            }
        }
        public void goDown()
        {
            if (y < 25)
            {
                y = y + 1;
            }
            else
            {
                y = y - 1;
            }

        }
        public void goLeft()
        {
            if (x > 0)
            {
                x = x - 1;
            }
            else
            {
                x = x + 1;
            }
        }
        public void goRight()
        {
            if (x < 75)
            {
                x = x + 1;
            }
            else
            {
                x = x - 1;
            }
        }
    }

    class Program
    {
        static Random rand = new Random(4);

        //this method is locked 
        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void outConsole(DancingStar star, string s)
        {
            Console.SetCursorPosition(star.x, star.y);
            Console.Write(s);
        }
        private static void goStar(int X, int Y)
        {
            DancingStar star = new DancingStar(X, Y);
            while (true)
            {
                outConsole(star, " "); //cleaning old *

                int h = rand.Next(4);   //generate the direction

                switch (h)
                {
                    case 0:
                        star.goDown();
                        break;
                    case 1:
                        star.goUp();
                        break;
                    case 2:
                        star.goLeft();
                        break;
                    case 3:
                        star.goRight();
                        break;
                }

                outConsole(star, "*");      //out
                Thread.Sleep(100);
            }
        }

        static void Main(string[] args)
        {

            Parallel.Invoke(() => goStar(80, 30), () => goStar(1, 10), () => goStar(40, 6), () => goStar(80, 20),
                            () => goStar(10, 10), () => goStar(15, 20), () => goStar(40, 5), () => goStar(60, 15),
                            () => goStar(15, 12), () => goStar(75, 11), () => goStar(80, 5), () => goStar(80, 0),
                            () => goStar(63, 8), () => goStar(74, 25), () => goStar(0, 0), () => goStar(80, 25));
            Console.ReadKey();
        }
    }
}
