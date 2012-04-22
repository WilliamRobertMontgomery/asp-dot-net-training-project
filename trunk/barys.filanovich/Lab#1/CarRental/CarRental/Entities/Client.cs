using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarRental.BusinessLogic;

namespace CarRental.Entities
{
    public class Client : IControl
    {
        public string Id { get; private set; }
        public string Name { get; private set; }

        CarRentalSystem carRental = new CarRentalSystem();

        public Client(string id)
        {
            if (carRental.SelectClient(id) != null)
            {

                this.Id = carRental.SelectClient(id).Id;
                this.Name = carRental.SelectClient(id).Name;
            }
        }

        public Client(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return string.Format("ID:{0}\r\nName:{1}", this.Id, this.Name);
        }

        private void ShowCars()
        {
            Console.WriteLine("All Cars:\r\n");
            carRental.ShowCars();
        }

        private void GetCar()
        {
            Console.WriteLine("Enter the ID of car, please: ");
            carRental.GetCar(this.Id, Console.ReadLine());
        }

        private void GetHelp()
        {
            Console.WriteLine(
                "To show car list enter 'showcars'\r\n" +
                "To set car for client enter 'getcar'\r\n" +
                "To view help enter 'help'\r\n" +
                "To quit enter 'quit'");
        }

        public void Control()
        {
            string command = null;

            if (this.Id == null)
            {
                Console.WriteLine("Client ID error!");
                Console.ReadKey();
                return;
            }

            this.GetHelp();
            do
            {
                command = Console.ReadLine();

                switch (command.ToLower())
                {
                    case ("showcars"): this.ShowCars(); break;
                    case ("getcar"): this.GetCar(); break;
                    case ("help"): this.GetHelp(); break;
                    case ("cls"): Console.Clear(); break;
                    default: Console.WriteLine("Is not recognized as an internal command."); break;
                }

            } while (string.Compare(command, "quit") != 0);
        }
    }
}
