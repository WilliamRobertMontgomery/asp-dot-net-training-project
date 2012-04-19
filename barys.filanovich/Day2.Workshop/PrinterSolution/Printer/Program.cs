using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPrinters
{
    class Program
    {
        static void Main(string[] args)
        {
            TestPrinterClass();
            TestLaserPrinterClass();
        }


        static void TestPrinterClass()
        {
            IPrinter printer = new Printer();

            printer.GetPrinterInfo();
            Console.WriteLine();

            printer.AddDoc(new Document());
            printer.AddDoc(new Document("My Doc",500));
            printer.AddDoc(new Document());
            printer.AddDoc(new Document());
            Console.WriteLine();

            printer.GetPrintQueue();
            Console.WriteLine();

            printer.Print();
            Console.WriteLine();

            printer.GetPrintQueue();
            Console.WriteLine();

            printer.Capacity();
            Console.WriteLine();

            printer.ReplaceCartrige(2000);
            Console.WriteLine();

            printer.Capacity();
            Console.WriteLine();

            printer.GetPrinterInfo();

        }

        static void TestLaserPrinterClass()
        {
            IPrinter laserPrinter = new LaserPrinter("PH 9999", 999, 16, true);

            for (int i = 0; i < 5; i++)
            {
                laserPrinter.AddDoc(new Document());
            }
            Console.WriteLine();

            laserPrinter.GetPrintQueue();
            Console.WriteLine();

            laserPrinter.ClearPrintQueue();
            Console.WriteLine();

            laserPrinter.GetPrintQueue();
            Console.WriteLine();

            laserPrinter.AddDoc(new Document("Test doc1", 333));
            laserPrinter.AddDoc(new Document("Test doc2", 555));
            Console.WriteLine();

            laserPrinter.AddDoc(new Document("Test doc3", 777));
            Console.WriteLine();

            laserPrinter.Print();
            laserPrinter.ReplaceCartrige();
            laserPrinter.AddDoc(new Document("Test doc3", 777));
            Console.WriteLine();

            laserPrinter.GetPrinterInfo();
            Console.WriteLine();

        }
    }
}
