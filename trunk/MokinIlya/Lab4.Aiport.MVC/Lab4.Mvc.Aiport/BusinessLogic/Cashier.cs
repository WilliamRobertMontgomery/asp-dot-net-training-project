using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab4.Mvc.Aiport.DataAccess;
using Lab4.Mvc.Aiport.Models;

namespace Lab4.Mvc.Aiport.BusinessLogic
{
    class CCashier
    {
        public CCashier(ref DataAccessBank bank, ref DataAccessBasicReis basicReis, ref DataAccessReis reis, ref DataAccessClients clients, ref DataAccessPlains aircrafts)
        {
            BankEntitie = bank;
            ReisEntitie = reis;
            ClientsEntitie = clients;
            BasicReisEntitie = basicReis;
            PlainsEntitie = aircrafts;
        }
        private DataAccessBank BankEntitie;
        private DataAccessReis ReisEntitie;
        private DataAccessBasicReis BasicReisEntitie;
        private DataAccessClients ClientsEntitie;
        private DataAccessPlains PlainsEntitie;

        //Генерация рейсов
        public string GenerateReis(DateTime t, int d)
        {
            return ReisEntitie.GenerateReises(t,d);
        }
        //Бронирование
        public string Reserve(string destination, DateTime nowTime)
        {
            //Выбираем все рейсы в искомую точку и сортируем по времени
            var basicReises = BasicReisEntitie.GetAll().Where(x => x.To.Trim() == destination.Trim()).Select(x => x.CodeBasicReis);
            var reises = ReisEntitie.GetAll().Where(x => basicReises.Contains((int)x.CodeBasicReis)).OrderBy(x => x.Date);
            //Выбираем из подходящих рейсов, рейсы на которые есть места
            var freeReises = reises.Where(x => PlainsEntitie.GetAll().Single(plain => plain.CodePlane == x.BasicReis.CodePlain).NumberOfSeats - ClientsEntitie.GetAll().Where(client => client.CodeReis == x.CodeReis).Count() > 0);
            //Выбираем первый, по времени, рейс на который есть места
            var total = freeReises.SkipWhile(x => x.Date < nowTime).DefaultIfEmpty(null).First();

            if (total != null)
            {
                Clients temp = new Clients();
                temp.BookOrBuy = false;
                temp.CodeReis = total.CodeReis;
                ClientsEntitie.AddElement(temp);
                return String.Format("Забронирован билет на рейс {0} в {1} на {2}", total.CodeReis, total.BasicReis.To.Trim(), total.Date);
            }
            else
            {
                return String.Format("Билетов в {0} нет на допустимый период", destination);
            }
        }
        //Покупка
        public string Sell(string destination, DateTime nowTime)
        {
            //Выбираем все рейсы в искомую точку и сортируем по времени
            var basicReises = BasicReisEntitie.GetAll().Where(x => x.To.Trim() == destination.Trim()).Select(x => x.CodeBasicReis);
            var reises = ReisEntitie.GetAll().Where(x => basicReises.Contains((int)x.CodeBasicReis)).OrderBy(x => x.Date);
            //Выбираем из подходящих рейсов, рейсы на которые есть места
            var freeReises = reises.Where(x => PlainsEntitie.GetAll().Single(plain => plain.CodePlane == x.BasicReis.CodePlain).NumberOfSeats - ClientsEntitie.GetAll().Where(client => client.CodeReis == x.CodeReis).Count() > 0);
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
                return String.Format("Продан билет на рейс {0} в {1} на {2}", total.CodeReis, total.BasicReis.To.Trim(), total.Date);
            }
            else
            {
                return String.Format("Билетов в {0} нет на допустимый период", destination);
            }
        }
        //Завершение бронирования(покупка)
        public string FinishReserve(int numberOfClient)
        {
            var total = ClientsEntitie.GetAll().DefaultIfEmpty().SingleOrDefault(x => x.CodeClient == numberOfClient);
            if (total != null)
            {
                total.BookOrBuy = true;
                ClientsEntitie.UpdateElement(total);

                Bank tempBank = new Bank();
                tempBank.Ammount = total.Reis.BasicReis.Price;
                tempBank.Date = total.Reis.Date;
                tempBank.Comment = String.Format("Платеж за билет на рейс {0}", total.CodeReis);
                BankEntitie.AddElement(tempBank);
                return String.Format("Продан билет на рейс {0} в {1} на {2}", total.CodeReis, total.Reis.BasicReis.To.Trim(), total.Reis.Date);
            }
            else
            {
                return String.Format("Клиент с таким номером не найден");
            }

        }
    }
}