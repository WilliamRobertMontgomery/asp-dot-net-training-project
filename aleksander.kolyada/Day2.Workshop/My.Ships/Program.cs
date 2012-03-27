using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My.Ships
{
    class Program
    {
        static void Main(string[] args)
        {
            Ship A = new Ship();
            A.sailTo("Port of Tokyo");
            A.action();
            Console.WriteLine();
            WarShip B = new WarShip("Flying Dutchman", 1000, 50000, 20);
            B.sailTo("Port of Santos");
            B.action();
            Console.WriteLine();
            AircraftCarrier C = new AircraftCarrier();
            C.Name = "Admiral Kuznetsov";
            C.Draft = 55000;
            C.NumberOfCrew = 3000;
            C.NumberOfAircrafts = 50;
            C.sailTo("USA");
            C.action();
            Console.ReadKey();
        }
    }
}
