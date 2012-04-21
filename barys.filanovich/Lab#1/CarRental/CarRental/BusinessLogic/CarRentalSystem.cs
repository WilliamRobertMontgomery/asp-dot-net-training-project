using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarRental.DataAccess;
using CarRental.Entities;

namespace CarRental.BusinessLogic
{
    public class CarRentalSystem
    {
        private const int timeout = 5;      //minutes
        private Car selectedCar = null;
        private Client selectedClient = null;

        private IRepository<Car> _carRepository = new CarRepository();
        private IRepository<Client> _clientRepository = new ClientRepository();

        public CarRentalSystem()
        {
            this.ResetCarStatus();
        }

        private void ResetCarStatus()
        {
            foreach(Car car in this.GetCars())
            {
                try
                {
                    if ((DateTime.Now - DateTime.Parse(car.DateOfLease)).Minutes > timeout)
                    {
                        car.Client = "free";
                        car.DateOfLease = null;
                        _carRepository.Save(car);
                    }
                }
                catch(FormatException)
                {
                    continue;
                }
            }
        }

        private Car[] GetCars()
        {
            return _carRepository.Read();
        }

        private Client[] GetClients()
        {
            return _clientRepository.Read();
        }

        public void AddCar(Car car)
        {
            if (!this.CarAvailable(car.Id))
            {
                _carRepository.Save(car);
                Console.WriteLine("The car was added.");
            }
            else
            {
                Console.WriteLine("This ID ({0}) is used.", car.Id);
            }
        }

        private bool CarAvailable(string id)
        {
            foreach (Car car in this.GetCars())
            {
                if (string.Compare(car.Id, id, false) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public void AddClient(Client client)
        {
            if (this.IdClientIsOK(client.Id))
            {
                _clientRepository.Save(client);
                Console.WriteLine("The client was added.");
            }
            else
            {
                Console.WriteLine("This ID ({0}) is used.", client.Id);
            }
        }

        private bool IdClientIsOK(string id)
        {
            foreach (Client client in this.GetClients())
            {
                if (string.Compare(client.Id, id) == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public void ShowClients()
        {
            foreach (Client client in this.GetClients())
            {
                Console.WriteLine(client);
                Console.WriteLine();
            }
        }

        public void ShowCars()
        {
            this.ResetCarStatus();
            foreach (Car car in this.GetCars())
            {
                Console.WriteLine(car);
                Console.WriteLine();
            }
        }

        private Client SelectClient(string id)
        {
            foreach (Client client in this.GetClients())
            {
                if (string.Compare(client.Id, id) == 0)
                {
                    return client;
                }
            }
            Console.WriteLine("Invalid ID of Client!");
            return null;
        }

        private Car SelectCar(string id)
        {
            foreach (Car car in this.GetCars())
            {
                if (string.Compare(car.Id, id, true) == 0)
                {
                    return car;
                }
            }
            Console.WriteLine("Invalid ID of Car!");
            return null;
        }

        public void GetCar(string clientId, string carId)
        {
            selectedClient = this.SelectClient(clientId);
            selectedCar =  this.SelectCar(carId);

            this.ResetCarStatus();
            if (selectedCar != null & selectedClient != null)
            {
                if (this.CarIsFree(selectedCar))
                {
                    selectedCar.Client = selectedClient.Id;
                    selectedCar.DateOfLease = DateTime.Now.ToString();
                    _carRepository.Save(selectedCar);
                    Console.WriteLine(selectedCar.ToString());
                }
                else
                {
                    Console.WriteLine("This car is used.");
                }
            }

            ResetSelected();
        }

        private bool CarIsFree(Car car)
        {
            if (car.DateOfLease == string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ResetSelected()
        {
            selectedCar = null;
            selectedClient = null;
        }

        public void RemoveClient(string id)
        {
            if (!this.IdClientIsOK(id))
            {
                _clientRepository.Remove(this.SelectClient(id));
            }
            else
            {
                Console.WriteLine("This ID of client is invalid!");
            }
        }

        public void RemoveCar(string id)
        {
            if (this.CarAvailable(id))
            {
                _carRepository.Remove(this.SelectCar(id));
            }
            else
            {
                Console.WriteLine("This ID of car is invalid!");
            }
        }
    }
}
