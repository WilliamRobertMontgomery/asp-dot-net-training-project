using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPrinters
{
    class LaserPrinter : Printer
    {
        int firtPageOutTime;

        public LaserPrinter()
            : base()
        {
            this.technology = PrintTechnology.TonerBased;
            firtPageOutTime = 10;
        }

        public LaserPrinter(string prinerName, int capacityCartridge, int firtPageOutTime, bool color)
            : base(prinerName,capacityCartridge, PrintTechnology.TonerBased, color)
        {
            this.firtPageOutTime = firtPageOutTime;
        }

        public void GetPrinterInfo()
        {
            Console.WriteLine("Test-page:");
            string result = string.Format(
                "Printer's name: {0}\nPages was printed: {1}\n" +
                "Capacity: {2} page(-s) is left\nColor: {3}\n" +
                "Print technology: {4}\nFirt page out time: {5}", 
                name, printedPages, capacityCartridge, color, technology, firtPageOutTime);
            Console.WriteLine(result);
        }
    }
}
