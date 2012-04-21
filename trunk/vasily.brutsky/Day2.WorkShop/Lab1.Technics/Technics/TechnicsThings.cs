using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Technics
{
    public class TechnicsThings
    {
        //Fields
        private int price;
        private string manufacturer;
        //Properties
        public int Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }
        public string Manufacturer
        {
            get
            {
                return manufacturer;
            }
            set
            {
                manufacturer = value;
            }
        }

        //Constructors
        public TechnicsThings()
        {
            price = 0;
            manufacturer = null;
        }

        public TechnicsThings(int thprice, string thmanufacturer)
        {
            price = thprice;
            manufacturer = thmanufacturer;
        }

        public virtual void PrintInformation()
        {
            Console.WriteLine( "Price :" + Price.ToString() + "; Manufacrurer: " + Manufacturer);
        }



        
    }
}
