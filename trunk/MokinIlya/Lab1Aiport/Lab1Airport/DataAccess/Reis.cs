using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1Airport.Entities;

namespace Lab1Airport
{
    public class AccessToReis : IRepository<Reis>
    {
        private int _lastId;

        public AccessToReis()
        {
            _lastId = 0;
        }

        public Reis GetElement(int id)
        {
            return DBAiportDataContext.Reis.SingleOrDefault(m => m.CodeReis == id);
        }

        public IEnumerable<Reis> GetAll()
        {
            return DBAiportDataContext.Reis;
        }

        public void AddElement(Reis element)
        {
            if (element.CodeReis == null)
            {
                element.CodeReis = _lastId;
                _lastId += 1;
            }
            if (element.BasicReis == null)
            {
                element.BasicReis = DBAiportDataContext.BasicReis.Find(x => x.CodeBasicReis == element.CodeBasicReis);
            }
            DBAiportDataContext.Reis.Add(element);
        }

        public void UpdateElement(Reis element)
        {
            int updateElementIndex = DBAiportDataContext.Reis.FindIndex(x => x == element);
            Reis updateElement = GetElement(element.CodeReis);
            if (updateElement != null)
            {
                updateElement.Date = element.Date;
                updateElement.CodeBasicReis = element.CodeBasicReis;
            }
            DBAiportDataContext.Reis[updateElementIndex] = updateElement;
        }

        public void DeleteElement(int id)
        {
            Reis element = GetElement(id);
            DBAiportDataContext.Reis.Remove(element);
        }

        public void DeleteElement(Reis element)
        {
            DeleteElement(element.CodeReis);
        }

        public void GenerateReises()
        {
            DateTime startTime; DateTime finishTime;

            Console.Clear();
            Console.WriteLine("Генерировать с DATE на DAYS дней");
            Console.Write("Введите DATE в формате dd/mm/yy: ");
            startTime = DateTime.Parse(Console.ReadLine());
            Console.Write("Введите DAYS: ");
            finishTime = startTime.AddDays(Int32.Parse(Console.ReadLine()));

            DateTime tempTime = new DateTime(startTime.Ticks);
            while (tempTime < finishTime)
            {
                var ticksOfDay = new TimeSpan(1, 0, 0, 0, 0);
                for (int i = 0; i < DBAiportDataContext.BasicReis.Count(); i++)
                {
                    var interval = new TimeSpan((int)DBAiportDataContext.BasicReis.AsEnumerable().ElementAt(i).Interval, 0, 0, 0, 0);
                    //Если попадаем на день, удовлетворяющий интервалу текущего рейса, то добавить рейс
                    //и установить ему время
                    if ((tempTime - (DateTime)DBAiportDataContext.BasicReis.AsEnumerable().ElementAt(i).Date).Ticks % interval.Ticks < ticksOfDay.Ticks)
                    {
                        Reis tempElementReis = new Reis();
                        tempElementReis.CodeBasicReis = DBAiportDataContext.BasicReis.AsEnumerable().ElementAt(i).CodeBasicReis;
                        tempElementReis.Date = tempTime;
                        AddElement(tempElementReis);
                    }
                }
                tempTime = tempTime.AddDays(1);
            }
            Console.WriteLine("Сгенерированы рейсы с {0} до {1} \nНажмите любую клавишу", startTime, finishTime);
            Console.ReadKey();
            Console.Clear();
        }
    }
}
