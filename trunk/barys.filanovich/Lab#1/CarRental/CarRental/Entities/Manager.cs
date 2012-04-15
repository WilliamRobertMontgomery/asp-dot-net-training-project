using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRental.Entities
{
    class Manager
    {
        static CarRentalSystem system = new CarRentalSystem();

        public static void GetCar(string brand,Client client)
        {
            system.GetCar(brand,client);
        }

        public static void ShowClients()
        {
            system.ShowCars();
        }

        public static void ShowCars()
        {
            system.ShowClients();
        }
    }
}
