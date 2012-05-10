using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1Airport
{
    

    class Program
    {
        static Random Rand = new Random();

        static void Main(string[] args)
        {
            //Инициализуруем и заполняем необходимые объекты
            AccessToBank Bank = new AccessToBank();
            AccessToBasicReis BasicReis = new AccessToBasicReis();
            AccessToReis Reis = new AccessToReis();
            AccessToClients Clients = new AccessToClients();
            AccessToPlanes Planes = new AccessToPlanes();

            AutoComplete.Complete(ref BasicReis, ref Planes);

            CCashier Cashier = new CCashier(ref Bank, ref BasicReis, ref Reis, ref Clients, ref Planes);

            OutMenu(Reis, Cashier);
        }

        private static void OutMenu(AccessToReis Reis, CCashier Cashier)
{
            Console.WriteLine("МЕНЮ");
            Console.WriteLine("1 - Генерация новых рейсов");
            Console.WriteLine("2 - Продать билет");
            Console.WriteLine("3 - Бронировать билет");
            Console.WriteLine("4 - Завершить бронирование билета");
            Console.WriteLine("5 - Выход");

            Console.Write("Выберите действие: ");
            string str = Console.ReadLine();
            switch (str)
            {
                case "1": 
                    Reis.GenerateReises();
                    OutMenu(Reis, Cashier);
                    break;
                case "2":
                    Cashier.Sell();
                    OutMenu(Reis, Cashier);
                    break;
                case "3":
                    Cashier.Reserve();
                    OutMenu(Reis, Cashier);
                    break;
                case "4":
                    Cashier.FinishReserve();
                    OutMenu(Reis, Cashier);
                    break;
                default:
                    break;
            }
}
    }
}
