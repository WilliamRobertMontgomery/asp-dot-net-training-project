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
            CReis Reis=new CReis();
            CBank Bank = new CBank();
            CAircrafts Aircrafts = new CAircrafts();
            CClients Clients = new CClients();
            CHelper.ReadOfDataBase(ref Aircrafts, ref Reis); //Заполням базу, из файла, стартовыми значениями

            DateTime startMoment = DateTime.Parse("02/04/2010");
            Reis.GenerateReises(startMoment, startMoment.AddDays(20));//генерируем рейсы на некоторый период
            CCashier Cashier = new CCashier(ref Bank, ref Reis, ref Clients, ref Aircrafts);//инициализируем кассира

            //Динамика
            Dynamics(Reis, startMoment, Cashier);

            Console.ReadKey();
        }

        private static void Dynamics(CReis Reis, DateTime startMoment, CCashier Cashier)
        {
            DateTime currentMoment = startMoment;
            while (currentMoment < startMoment.AddDays(20))
            {
                //Определяем число заявок на покупку
                int countForSell = Rand.Next(10);
                for (int i = 0; i < countForSell; i++)
                {
                    Sell(Reis, Cashier, currentMoment);
                    System.Threading.Thread.Sleep(400);
                }
                currentMoment = currentMoment.AddDays(1);
                //Определяем число заявок на бронирование
                int countForReserve = Rand.Next(3);
                for (int i = 0; i < countForReserve; i++)
                {
                    Reserve(Reis, Cashier, currentMoment);
                    System.Threading.Thread.Sleep(400);
                }
                currentMoment = currentMoment.AddDays(1);

            }
        }

        private static void Sell(CReis Reis, CCashier Cashier, DateTime currentMoment)
        {
            //Генерируем наименование пункта назначения
            int index = Rand.Next(Reis.ReisItemBasic.Count);
            string destination = Reis.ReisItemBasic.ElementAt(index).Destination;
            var total = Cashier.Sell(destination, currentMoment);
            if (total != null)
            {
                Console.WriteLine("Продан билет в {0} на {1}", destination, total.StartTime);
            }
            else
            {
                Console.WriteLine("Билетов в {0} в допустимом периоде нет", destination);
            }
        }

        private static void Reserve(CReis Reis, CCashier Cashier, DateTime currentMoment)
        {
            //Генерируем наименование пункта назначения
            int index = Rand.Next(Reis.ReisItemBasic.Count);
            string destination = Reis.ReisItemBasic.ElementAt(index).Destination;
            var total = Cashier.Sell(destination, currentMoment);
            if (total != null)
            {
                Console.WriteLine("Бронирован билет в {0} на {1}", destination, total.StartTime);
            }
            else
            {
                Console.WriteLine("Билетов в {0} в допустимом периоде нет", destination);
            }
        }
    }
}
