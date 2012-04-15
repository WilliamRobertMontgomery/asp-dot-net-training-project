using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CarRental.Entities;
using CarRental.DataAccess;
using CarRental.BusinessLogic;

namespace CarRental
{
    class Program
    {
        static void Main(string[] args)
        {

            Manager.ShowCars();
            Console.WriteLine();
            Manager.ShowClients();


        }

        static void GenerateSomeCarRental()
        {
            Client clien1 = new Client("111", "Mr.Jonson");
            Client clien2 = new Client("123", "Mr.Anderson");
            Client clien3 = new Client("124", "Mr.Pietersen");

            ClientRepository.Save(clien1);
            ClientRepository.Save(clien2);
            ClientRepository.Save(clien3);

            Car car1 = new Car("Mercedes-Benz");
            Car car2 = new Car("BMW");
            Car car3 = new Car("Audi");
            Car car4 = new Car("Ferrari");

            CarRepository.Save(car1);
            CarRepository.Save(car2);
            CarRepository.Save(car3);
            CarRepository.Save(car4);
        }
    }
}
