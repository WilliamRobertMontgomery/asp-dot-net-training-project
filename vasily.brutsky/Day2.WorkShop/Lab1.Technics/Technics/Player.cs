using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Technics
{
    class Player:TechnicsThings
    {
        //fields
        private string recordingformat;
        //properties
        public string RecordingFormat
        {
            get
            {
                return recordingformat;
            }
            set
            {
                recordingformat = value;
            }
        }

        //constructors
        public Player()
        {
            this.Price = 0;
            this.Manufacturer = null;
            this.RecordingFormat = null;
        }

        public Player(int thprice, string thmanufacturer, string threcordingformat)
        {
            this.Price = thprice;
            this.Manufacturer = thmanufacturer;
            this.RecordingFormat = threcordingformat;
        }

        //polymorphism
        public override void PrintInformation()
        {
            Console.WriteLine( "Price :" + Price.ToString() + "; Manufacrurer: " + Manufacturer + "; RecordingFormat: " + RecordingFormat);
        }



        

    }
}
