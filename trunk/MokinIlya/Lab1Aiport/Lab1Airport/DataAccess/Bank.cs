using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1Airport.Entities;

namespace Lab1Airport
{
    public class AccessToBank : IRepository<Bank>
    {
        private int _lastId;

        public AccessToBank()
        {
            _lastId = 0;
        }

        public Bank GetElement(int id)
        {
            return DBAiportDataContext.Bank.SingleOrDefault(m => m.CodePayment == id);
        }

        public IEnumerable<Bank> GetAll()
        {
            return DBAiportDataContext.Bank;
        }

        public void AddElement(Bank element)
        {

            element.CodePayment = _lastId;
            _lastId += 1;

            DBAiportDataContext.Bank.Add(element);
        }

        public void UpdateElement(Bank element)
        {
            int updateElementIndex = DBAiportDataContext.Bank.FindIndex(x => x == element);
            Bank updateElement = GetElement(element.CodePayment);
            if (updateElement != null)
            {
                updateElement.Ammount = element.Ammount;
                updateElement.Comment = element.Comment;
                updateElement.Date = element.Date;
            }
            DBAiportDataContext.Bank[updateElementIndex] = updateElement;
        }

        public void DeleteElement(int id)
        {
            Bank element = GetElement(id);
            DBAiportDataContext.Bank.Remove(element);
        }

        public void DeleteElement(Bank element)
        {
            DeleteElement(element.CodePayment);
        }
    }
}
