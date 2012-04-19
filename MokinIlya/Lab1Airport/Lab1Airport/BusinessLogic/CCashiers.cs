using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1Airport
{


    class CCashier
    {
        public CCashier(ref CBank bank, ref CReis reis, ref CClients clients, ref CAircrafts aircrafts)
        {
            Bank = bank;
            Reis = reis;
            Clients = clients;
            Aircrafts = aircrafts;
        }
        private CBank Bank;
        private CReis Reis;
        private CClients Clients;
        private CAircrafts Aircrafts;

        //Бронирование
        public CReis.CReisItem Reserve(string destination, DateTime nowTime)
        {
            //Выбираем все рейсы в искомую точку и сортируем по времени
            var reises = Reis.ReisItem.Where(x => x.Destination == destination).OrderBy(x => x.StartTime);
            //считаем число оставшихся мест в каждую точку
            var freePlaces = Reis.ReisItem.Select(x => Aircrafts.AircraftsItem.ElementAt(x.NumberOfAircraft).NumberOfSeats - Clients.ClientItem.Where(x2 => x2.NumberOfReis == x.NumberOfReis).Count());
            //Выбираем первый, по времени, рейс на который есть места
            var total = reises.SkipWhile(x => x.StartTime < nowTime).SkipWhile((x, index) => freePlaces.ElementAt(index) == 0).DefaultIfEmpty(null).First();

            if (total != null)
            {
                Clients.Add(Clients.ClientItem.Count, total.NumberOfReis, false);
                return total;
            }
            else
            {
                return null;
            }
        }
        //Покупка
        public CReis.CReisItem Sell(string destination, DateTime nowTime)
        {
            //Выбираем все рейсы в искомую точку и сортируем по времени
            var reises = Reis.ReisItem.Where(x => x.Destination == destination).OrderBy(x=>x.StartTime);
            //считаем число оставшихся мест в каждую точку
            IEnumerable<int> freePlaces = Reis.ReisItem.Select(reisItem => Aircrafts.AircraftsItem.Single(AircraftsItem => reisItem.NumberOfAircraft == AircraftsItem.NumberOfAircraft).NumberOfSeats - Clients.ClientItem.Where(x2 => x2.NumberOfReis == reisItem.NumberOfReis).Count());
            //Выбираем первый, по времени, рейс на который есть места, отсеяв ушедшие рейсы
            var total = reises.SkipWhile(x => x.StartTime < nowTime).SkipWhile((x, index) => freePlaces.ElementAt(index) == 0).DefaultIfEmpty(null).First();

            if (total != null)
            {
                //Добавляем в клиенты
                Clients.Add(Clients.ClientItem.Count, total.NumberOfReis, true);
                //Ложим деньги в банк
                Bank.Add(total.Price, nowTime, "Reis " + total.NumberOfReis.ToString());
                return total;
            }
            else
            {
                return null;
            }
            
        }
        //Завершение бронирования(покупка)
        public bool FinishReserve(int numberOfClient, DateTime nowTime)
        {
            var total = Clients.FinishReserve(numberOfClient);
            if (total != null)
            {
                double money = Reis.ReisItem.Single(x => x.NumberOfReis == total.NumberOfReis).Price;
                Bank.Add(money, nowTime, "Reis " + total.NumberOfReis.ToString());
                return true;
            }
            else
            {
                return false;
            }
        }
        //Отмена бронирования по клиенту
        public bool CanselReserveByClient(int numberOfClient)
        {
            var total = Clients.ClientItem.Single(x => x.NumderOfClient == numberOfClient);
            if (total != null)
            {
                Clients.Delete(total.NumderOfClient);
                return true;
            }
            else
            {
                return false;
            }
            
        }
        //Отмена бронирования по рейсу
        public bool CanselReserveByReis(int numberOfReis)
        {
            Clients.ClientItem.RemoveAll(x => x.NumberOfReis == numberOfReis);
            return true;
        }

    }
}
