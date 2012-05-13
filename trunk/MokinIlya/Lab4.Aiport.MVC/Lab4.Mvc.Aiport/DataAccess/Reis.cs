using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab4.Mvc.Aiport.Models;
using Lab4.Mvc.Aiport.Repository;

namespace Lab4.Mvc.Aiport.DataAccess
{
    public class DataAccessReis : IRepository<Reis>
    {
        private DBAiportDataContext _context;

        public DataAccessReis()
        {
            _context = new DBAiportDataContext();
        }

        public Reis GetElement(int id)
        {
            return _context.Reis.SingleOrDefault(m => m.CodeReis == id);
        }

        public IEnumerable<Reis> GetAll()
        {
            return _context.Reis.AsEnumerable<Reis>();
        }

        public void AddElement(Reis element)
        {
            _context.Reis.InsertOnSubmit(element);
            _context.SubmitChanges();
        }

        public void UpdateElement(Reis element)
        {
            Reis updateElement = GetElement(element.CodeReis);
            if (updateElement != null)
            {
                updateElement.Date = element.Date;
                updateElement.CodeBasicReis = element.CodeBasicReis;
                _context.SubmitChanges();
            }
        }

        public void DeleteElement(int id)
        {
            Reis element = GetElement(id);
            _context.Reis.DeleteOnSubmit(element);
            _context.SubmitChanges();
        }

        public void DeleteElement(Reis element)
        {
            DeleteElement(element.CodeReis);
        }

        public string GenerateReises(DateTime startTime, int days)
        {
            DateTime finishTime = startTime.AddDays(days);

            DateTime tempTime = new DateTime(startTime.Ticks);
            while (tempTime < finishTime)
            {
                var ticksOfDay = new TimeSpan(1, 0, 0, 0, 0);
                for (int i = 0; i < _context.BasicReis.Count(); i++)
                {
                    var interval = new TimeSpan((int)_context.BasicReis.AsEnumerable().ElementAt(i).Interval, 0, 0, 0, 0);
                    //Если попадаем на день, удовлетворяющий интервалу текущего рейса, то добавить рейс
                    //и установить ему время
                    if ((tempTime - (DateTime)_context.BasicReis.AsEnumerable().ElementAt(i).Date).Ticks % interval.Ticks < ticksOfDay.Ticks)
                    {
                        Reis tempElementReis = new Reis();
                        tempElementReis.CodeBasicReis = _context.BasicReis.AsEnumerable().ElementAt(i).CodeBasicReis;
                        tempElementReis.Date = tempTime;
                        AddElement(tempElementReis);
                    }
                }
                tempTime = tempTime.AddDays(1);
            }

            return String.Format("Сгенерированы рейсы с {0} до {1}", startTime, finishTime);
        }
    }
}