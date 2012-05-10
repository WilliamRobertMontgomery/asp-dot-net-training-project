using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1Airport.Repository;

namespace Lab1Airport
{
    public class DataAccessBasicReis:IRepository<BasicReis>
    {
        private DBAiportDataContext _context;

        public DataAccessBasicReis()
        {
            _context = new DBAiportDataContext();
        }

        public BasicReis GetElement(int id)
        {
            return _context.BasicReis.SingleOrDefault(m => m.CodeBasicReis == id);
        }

        public IEnumerable<BasicReis> GetAll()
        {
            return _context.BasicReis.AsEnumerable<BasicReis>();
        }

        public void AddElement(BasicReis element)
        {
            _context.BasicReis.InsertOnSubmit(element);
            _context.SubmitChanges();
        }

        public void UpdateElement(BasicReis element)
        {
            BasicReis updateElement = GetElement(element.CodeBasicReis);
            if (updateElement != null)
            {
                updateElement.To = element.To;
                updateElement.Date = element.Date;
                updateElement.Price = element.Price;
                updateElement.Interval = element.Interval;
                updateElement.CodePlain = element.CodePlain;
                _context.SubmitChanges();
            }
        }

        public void DeleteElement(int id)
        {
            BasicReis element = GetElement(id);
            _context.BasicReis.DeleteOnSubmit(element);
            _context.SubmitChanges();
        }

        public void DeleteElement(BasicReis element)
        {
            DeleteElement(element.CodeBasicReis);
        }


        public void OutToConsole()
        {
            var reis = GetAll();
            foreach (var NReis in reis)
            {
                Console.SetCursorPosition(60,Console.CursorTop);
                Console.WriteLine(NReis.To.Trim());
            }
            Console.SetCursorPosition(0, 0);
        }
    }
}
