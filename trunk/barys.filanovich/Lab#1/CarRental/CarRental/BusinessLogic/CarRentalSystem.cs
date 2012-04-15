using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarRental.DataAccess;
using CarRental.BusinessLogic;

namespace CarRental.Entities
{
    public class CarRentalSystem
    {
        Client[] clients;
        Client selectedClient;
        Car[] cars;

        public CarRentalSystem()
        {
            cars = CarRepository.GetCars();
            clients = ClientRepository.GetClients();
            Reset();
        }

        public Client Client
        {
            get
            {
                if (selectedClient != null)
                    return selectedClient;
                return null;
            }
        }

        public void SelectClient(int num)
        {
            if (num >= 0 && num < clients.Length)
                selectedClient = clients[num];
            else
                Console.WriteLine("Client error!");
        }

        public void ShowClients()
        {
            foreach (Client client in clients)
                Console.WriteLine(client);
        }

        public void ShowCars()
        {
            foreach (Car car in cars)
                Console.WriteLine(car);
        }

        public void GetCar(string brand,Client client)
        {
            for (int i = 0; i < cars.Length; i++)
            {
                if (string.Compare(cars[i].BrandName, brand, true)==0)
                {
                    if (cars[i].Status == "free")
                    {
                        cars[i].Status = client.Id;
                        cars[i].DateOfLease = DateTime.Now.ToString();
                        CarRepository.Save(cars[i]);
                    }
                    else
                    {
                        int timeOut = 10-(DateTime.Now - DateTime.Parse(cars[i].DateOfLease)).Minutes;

                        Console.WriteLine("This car will be free after {0} min",
                            timeOut);
                    }
                }
            }
        }

        public void Reset()
        {
            for (int i = 0; i < cars.Length; i++)
            {
                if (string.Compare(cars[i].Status, "free", true) == 0)
                {
                    continue;
                }

                int timeOut = 10-(DateTime.Now - DateTime.Parse(cars[i].DateOfLease)).Minutes;
                if (timeOut <= 0)
                {
                    cars[i].Status = "free";
                    cars[i].DateOfLease = null;
                    CarRepository.Save(cars[i]);
                    cars = CarRepository.GetCars();
                    clients = ClientRepository.GetClients();
                }
            }
        }
    }
}
