using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1Airport.Entities;

namespace Lab1Airport
{
    public class AccessToBasicReis : IRepository<BasicReis>
    {
        private int _lastId;

        public AccessToBasicReis()
        {
            _lastId = 0;
        }

        public BasicReis GetElement(int id)
        {
            return DBAiportDataContext.BasicReis.SingleOrDefault(m => m.CodeBasicReis == id);
        }

        public IEnumerable<BasicReis> GetAll()
        {
            return DBAiportDataContext.BasicReis;
        }

        public void AddElement(BasicReis element)
        {

            element.CodeBasicReis = _lastId;
            _lastId += 1;


            element.Planes = DBAiportDataContext.Planes.Find(x => x.CodePlane == element.CodePlain);

            DBAiportDataContext.BasicReis.Add(element);
        }

        public void UpdateElement(BasicReis element)
        {
            int updateElementIndex = DBAiportDataContext.BasicReis.FindIndex(x => x == element);
            BasicReis updateElement = new BasicReis();
            if (updateElement != null)
            {
                updateElement.To = element.To;
                updateElement.Date = element.Date;
                updateElement.Price = element.Price;
                updateElement.Interval = element.Interval;
                updateElement.CodePlain = element.CodePlain;
            }
            DBAiportDataContext.BasicReis[updateElementIndex] = updateElement;
        }

        public void DeleteElement(int id)
        {
            BasicReis element = GetElement(id);
            DBAiportDataContext.BasicReis.Remove(element);
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
                Console.SetCursorPosition(60, Console.CursorTop);
                Console.WriteLine(NReis.To.Trim());
            }
            Console.SetCursorPosition(0, 0);
        }
    }
}
