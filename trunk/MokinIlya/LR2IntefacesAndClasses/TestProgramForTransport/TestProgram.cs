using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MOVING;
namespace TestProgramForTransport
{
    public class TestProgram
    {
        static void Main(string[] args)
        {
            Truck truck = new Truck("ВИТЯЗЬ", 10, 45);
            truck.OpenFrontLeftDoor();
            truck.SetLoad("ВИСКИ");
            truck.CloseFrontLeftDoor();
            truck.StartTheAuto();
            truck.MoveUpTo(10);
            truck.LoadTheTruck();
            truck.MoveDownTo(150);
            truck.UnloadTheTrack();
            truck.TurnOfTheAuto();

            Console.WriteLine();
            Transport transport = new Transport(11, 0);
            transport.MoveUpTo(50);

            Console.WriteLine();
            Auto auto = new Auto("Audi",11, 0);
            auto.MoveUpTo(50);
            auto.OpenFrontLeftDoor();
            auto.CloseFrontLeftDoor();
            auto.StartTheAuto();
            auto.MoveDownTo(52);
            auto.TurnOfTheAuto();

            Console.ReadKey();
        }
    }
}
