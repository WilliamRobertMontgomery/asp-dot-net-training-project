using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1Airport
{
    class CReis
    {
        public class CReisItem
        {
            public CReisItem(int numberOfReis, double price, DateTime time,int interval,string destination, int numberOfAircraft)
            {
                NumberOfReis = numberOfReis;
                Price = price;
                StartTime = time;
                Interval = interval;
                Destination = destination;
                NumberOfAircraft = numberOfAircraft;
            }
            
            public int NumberOfReis;
            public double Price { get; set; }
            public DateTime StartTime { get; set; }
            public int Interval { get; set; } //Days
            public string Destination { get; set; }
            public int NumberOfAircraft { get; set; }
        }

        //Первые вылетыты каждого типа рейсов
        public List<CReisItem> ReisItemBasic; 

        public List<CReisItem> ReisItem;

        public CReis()
        {
            ReisItemBasic = new List<CReisItem>();
            ReisItem = new List<CReisItem>();
        }

        //генерирует рейсы на основе ReisItemBasic для заданного периода и заносит их в ReisItem
        public int GenerateReises(DateTime startTime, DateTime finishTime)
        {
            while (startTime < finishTime)
            {
                var ticksOfDay = new TimeSpan(1, 0, 0, 0, 0);
                for (int i = 0; i < ReisItemBasic.Count; i++)
                {
                    var interval = new TimeSpan(ReisItemBasic.ElementAt(i).Interval, 0, 0, 0, 0);
                    //Если попадаем на день, удовлетворяющий интервалу текущего рейса, то добавить рейс
                    //и установить ему время
                    if ((startTime - ReisItemBasic.ElementAt(i).StartTime).Ticks % interval.Ticks < ticksOfDay.Ticks)
                    {
                        var NumberOfReis = ReisItemBasic.ElementAt(i).NumberOfReis;
                        var Price = ReisItemBasic.ElementAt(i).Price;
                        var Interval = ReisItemBasic.ElementAt(i).Interval;
                        var Destination = ReisItemBasic.ElementAt(i).Destination;
                        var NumberOfAircraft = ReisItemBasic.ElementAt(i).NumberOfAircraft;
                        var element = new CReisItem(NumberOfReis, Price, startTime, Interval, Destination, NumberOfAircraft);
                        ReisItem.Add(element);
                    }
                }
                startTime = startTime.AddDays(1);
            }
            return 1;
        }

        public bool Add(int NumberOfReis, double Prise, DateTime Time,int Interval, string Destination, int NumberOfAircraft)
        {
            ReisItemBasic.Add(new CReisItem(NumberOfReis, Prise, Time, Interval, Destination, NumberOfAircraft));
            return true;
        }
    }
}
