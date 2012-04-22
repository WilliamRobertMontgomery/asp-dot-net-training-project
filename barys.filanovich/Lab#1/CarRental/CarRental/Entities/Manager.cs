using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarRental.BusinessLogic;
using CarRental.DataAccess;

namespace CarRental.Entities
{
    class Manager : IControl
    {
        CarRentalSystem carRental = new CarRentalSystem();

        private void AddCar()
        {
            string id;
            string brand;

            Console.Write("Enter ID of car:");
            id = Console.ReadLine();
            Console.Write("Enter Brand of car:");
            brand = Console.ReadLine();

            carRental.AddCar(new Car(id, brand));
        }

        private void AddClient()
        {
            string id;
            string name;

            Console.Write("Enter ID of client:");
            id = Console.ReadLine();
            Console.Write("Enter name of client:");
            name = Console.ReadLine();

            carRental.AddClient(new Client(id, name));
        }

        private void ShowClients()
        {
            Console.WriteLine("All Clients:\r\n");
            carRental.ShowClients();
        }
        
        private void ShowCars()
        {
            Console.WriteLine("All Cars:\r\n");
            carRental.ShowCars();
        }
        
        private void SetCar()
        {
            string clientId = null;
            string carId = null;

            Console.WriteLine("Enter the ID of client, please: ");
            clientId = Console.ReadLine();
            Console.WriteLine("Enter the ID of car, please: ");
            carId = Console.ReadLine();

            carRental.GetCar(clientId, carId);
        }

        private void RemoveClient()
        {
            Console.Write("Enter ID of client:");

            carRental.RemoveClient(Console.ReadLine());

            Console.WriteLine("Client was removed.");
        }

        private void RemoveCar()
        {
            Console.Write("Enter ID of car:");

            carRental.RemoveCar(Console.ReadLine());

            Console.WriteLine("Car was removed.");
        }

        private void GetHelp()
        {
            Console.WriteLine(
                "To add new car enter 'newcar'\r\n" +
                "To add new client enter 'newclient'\r\n" +
                "To remove the client enter 'delclient'\r\n" +
                "To remove the car enter 'delcars'\r\n" +
                "To show client list enter 'showclients'\r\n" +
                "To show car list enter 'showcar'\r\n" +
                "To set car for client enter 'setcar'\r\n" +
                "To view help enter 'help'\r\n" +
                "To quit enter 'quit'");
        }

        public void Control()
        {
            string command = null;

            this.GetHelp();

            do
            {
                command = Console.ReadLine();

                switch (command.ToLower())
                {
                    case ("showclients"):
                        this.ShowClients();
                        break;
                    case ("showcars"):
                        this.ShowCars();
                        break;
                    case ("setcar"):
                        this.SetCar();
                        break;
                    case ("newcar"):
                        this.AddCar();
                        break;
                    case ("newclient"):
                        this.AddClient();
                        break;
                    case("delclient"):
                        this.RemoveClient();
                        break;
                    case ("delcar"):
                        this.RemoveCar();
                        break;
                    case ("help"):
                        this.GetHelp();
                        break;
                    case ("cls"):
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Is not recognized as an internal command.");
                        break;
                }

            } while (string.Compare(command, "quit") != 0);
        }
    }
}
