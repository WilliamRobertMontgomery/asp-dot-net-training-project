using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Technics
{
    class VideoPlayer:Player
    {
        //fields
        private string matrix;
        //properties
        public string Matrix
        {
            get
            {
                return matrix;
            }
            set
            {
                matrix = value;
            }
        }
        //constructors
         public VideoPlayer()
        {
            this.Price = 0;
            this.Manufacturer = null;
            this.RecordingFormat = null;
            this.Matrix = null;
        }

        public VideoPlayer(int thprice, string thmanufacturer, string threcordingformat, string thmatrix)
        {
            this.Price = thprice;
            this.Manufacturer = thmanufacturer;
            this.RecordingFormat = threcordingformat;
            this.Matrix = thmatrix;
        }


        //polymorphism
        public override void PrintInformation()
        {
            Console.WriteLine("Price :" + Price.ToString() + "; Manufacrurer: " + Manufacturer + "; RecordingFormat: " + RecordingFormat + "; Matrix: " + Matrix);
        }

        static void Main(string[] args)
        {
            TechnicsThings a = new TechnicsThings(120, "SONY");
            Console.WriteLine("TechnicsThings a: ");
            a.PrintInformation();
            Player b = new Player();
            b.Price = 1000;
            b.Manufacturer = "Apple";
            b.RecordingFormat = "*.WMA";
            Console.WriteLine("Player b: ");
            b.PrintInformation();
            VideoPlayer d = new VideoPlayer(1000, "Canon", "*.AVI", "CMOS");
            Console.WriteLine("VideoPlayer d: ");
            d.PrintInformation();
            Console.ReadKey();

        }

    }
}
