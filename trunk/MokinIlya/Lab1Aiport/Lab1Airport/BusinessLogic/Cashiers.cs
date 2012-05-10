using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1Airport.Entities;

namespace Lab1Airport
{


    class CCashier
    {
        public CCashier(ref AccessToBank bank,ref AccessToBasicReis basicReis, ref AccessToReis reis, ref AccessToClients clients, ref AccessToPlanes aircrafts)
        {
            BankEntitie = bank;
            ReisEntitie = reis;
            ClientsEntitie = clients;
            BasicReisEntitie = basicReis;
            PlanesEntitie = aircrafts;
        }
        private AccessToBank BankEntitie;
        private AccessToReis ReisEntitie;
        private AccessToBasicReis BasicReisEntitie;
        private AccessToClients ClientsEntitie;
        private AccessToPlanes PlanesEntitie;
        
        //Бронирование
        public void Reserve()
        {
            Console.Clear();
            BasicReisEntitie.OutToConsole();

            Console.Write("Введите пункт назначения: ");
            string destination = Console.ReadLine();
            Console.Clear();
            Console.Write("Укажите текущую дату в формате dd/mm/yy: ");
            DateTime nowTime = DateTime.Parse(Console.ReadLine());

            //Выбираем все рейсы в искомую точку и сортируем по времени
            var basicReises = BasicReisEntitie.GetAll().Where(x => x.To.Trim() == destination.Trim()).Select(x => x.CodeBasicReis);
            var reises = ReisEntitie.GetAll().Where(x => basicReises.Contains((int)x.CodeBasicReis)).OrderBy(x => x.Date);
            //Выбираем из подходящих рейсов, рейсы на которые есть места
            var freeReises = reises.Where(x => PlanesEntitie.GetAll().Single(plain => plain.CodePlane == x.BasicReis.CodePlain).NumberOfSeats - ClientsEntitie.GetAll().Where(client => client.CodeReis == x.CodeReis).Count() > 0);
            //Выбираем первый, по времени, рейс на который есть места
            var total = freeReises.SkipWhile(x => x.Date < nowTime).DefaultIfEmpty(null).First();

            if (total != null)
            {
                Clients temp = new Clients();
                temp.BookOrBuy = false;
                temp.CodeReis = total.CodeReis;
                ClientsEntitie.AddElement(temp);
                Console.WriteLine("Забронирован билет на рейс {0} в {1} на {2}", total.CodeReis, total.BasicReis.To.Trim(), total.Date);
            }
            else
            {
                Console.WriteLine("Билетов в {0} нет на допустимый период", destination);
            }
            Console.WriteLine("Нажмите любую клавишу");
            Console.ReadKey();
            Console.Clear();
        }
        //Покупка
        public void Sell()
        {
            Console.Clear();
            BasicReisEntitie.OutToConsole();
            Console.Write("Введите пункт назначения: ");
            string destination = Console.ReadLine();
            Console.Clear();
            Console.Write("Укажите текущую дату в формате dd/mm/yy: ");
            DateTime nowTime = DateTime.Parse(Console.ReadLine());

            //Выбираем все рейсы в искомую точку и сортируем по времени
            var basicReises = BasicReisEntitie.GetAll().Where(x => x.To.Trim() == destination.Trim()).Select(x => x.CodeBasicReis);
            var reises = ReisEntitie.GetAll().Where(x => basicReises.Contains((int)x.CodeBasicReis)).OrderBy(x => x.Date);
            //Выбираем из подходящих рейсов, рейсы на которые есть места
            var freeReises = reises.Where(x => PlanesEntitie.GetAll().Single(plain => plain.CodePlane == x.BasicReis.CodePlain).NumberOfSeats - ClientsEntitie.GetAll().Where(client => client.CodeReis == x.CodeReis).Count() > 0);
            //Выбираем первый, по времени, рейс на который есть места
            var total = freeReises.SkipWhile(x => x.Date < nowTime).DefaultIfEmpty(null).First();

            if (total != null)
            {
                Clients tempClient = new Clients();
                tempClient.BookOrBuy = true;
                tempClient.CodeReis = total.CodeReis;
                ClientsEntitie.AddElement(tempClient);

                Bank tempBank = new Bank();
                tempBank.Ammount = total.BasicReis.Price;
                tempBank.Date = total.Date;
                tempBank.Comment = String.Format("Платеж за билет на рейс {0}", total.CodeReis);
                BankEntitie.AddElement(tempBank);
                Console.WriteLine("Продан билет на рейс {0} в {1} на {2}", total.CodeReis, total.BasicReis.To.Trim(), total.Date);
            }
            else
            {
                Console.WriteLine("Билетов в {0} нет на допустимы период", destination);
            }
            Console.WriteLine("Нажмите любую клавишу");
            Console.ReadKey();
            Console.Clear();
        }
        //Завершение бронирования(покупка)
        public void FinishReserve()
        {
            Console.Clear();
            ClientsEntitie.OutToConsole();

            Console.Write("Введите номер клиента: ");
            int numberOfClient = Int32.Parse(Console.ReadLine());
            Console.Clear();

            var total = ClientsEntitie.GetAll().DefaultIfEmpty().SingleOrDefault(x=>x == null ? false : x.CodeClient==numberOfClient);
            if (total != null)
            {
                total.BookOrBuy = true;
                ClientsEntitie.UpdateElement(total);

                Bank tempBank = new Bank();
                tempBank.Ammount = total.Reis.BasicReis.Price;
                tempBank.Date = total.Reis.Date;
                tempBank.Comment = String.Format("Платеж за билет на рейс {0}", total.CodeReis);
                BankEntitie.AddElement(tempBank);
                Console.WriteLine("Продан билет на рейс {0} в {1} на {2}", total.CodeReis, total.Reis.BasicReis.To.Trim(), total.Reis.Date);
            }
            else
            {
                Console.WriteLine("Клиент с таким номером не найден");
            }
            Console.WriteLine("Нажмите любую клавишу");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
