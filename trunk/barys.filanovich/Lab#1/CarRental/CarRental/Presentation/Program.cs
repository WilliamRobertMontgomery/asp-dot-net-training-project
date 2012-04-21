using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CarRental.Entities;
using CarRental.BusinessLogic;

namespace CarRental
{
    class Program
    {
        static void Main(string[] args)
        {
            string entity = null;
            IControl control = null;

            //GenerateTestCarRental();

            Console.WriteLine(
                "Enter 'manager' or 'client' to enter in Car Rental system. " +
                "Or enter 'generate' to generate initial data.");

            entity = Console.ReadLine();

            switch (entity.ToLower())
            {
                case ("manager"):
                    control = new Manager();
                    Console.WriteLine("Manager control:");
                    control.Control();
                    break;
                case ("client"):
                    control = new Client();
                    break;
                case ("generate"):
                    GenerateTestCarRental();
                    break;
                default:
                    Console.WriteLine("Is not recognized as an internal command.");
                    break;
            }
        }

        static void GenerateTestCarRental()
        {
            CarRentalSystem carRental = new CarRentalSystem();

            Client clien1 = new Client("111", "Mr.Jonson");
            Client clien2 = new Client("222", "Mr.Anderson");
            Client clien3 = new Client("333", "Mr.Pietersen");

            carRental.AddClient(clien1);
            carRental.AddClient(clien2);
            carRental.AddClient(clien3);

            Car car1 = new Car("1111", "Mercedes-Benz");
            Car car2 = new Car("2222", "BMW");
            Car car3 = new Car("3333", "Audi");
            Car car4 = new Car("4444", "Ferrari");

            carRental.AddCar(car1);
            carRental.AddCar(car2);
            carRental.AddCar(car3);
            carRental.AddCar(car4);
        }
    }
}
