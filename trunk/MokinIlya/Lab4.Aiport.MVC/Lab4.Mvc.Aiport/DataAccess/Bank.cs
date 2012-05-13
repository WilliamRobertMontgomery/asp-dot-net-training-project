﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab4.Mvc.Aiport.Models;
using Lab4.Mvc.Aiport.Repository;

namespace Lab4.Mvc.Aiport.DataAccess
{
    public class DataAccessBank : IRepository<Bank>
    {
        private DBAiportDataContext _context;

        public DataAccessBank()
        {
            _context = new DBAiportDataContext();
        }

        public Bank GetElement(int id)
        {
            return _context.Bank.SingleOrDefault(m => m.CodePayment == id);
        }

        public IEnumerable<Bank> GetAll()
        {
            return _context.Bank.AsEnumerable<Bank>();
        }

        public void AddElement(Bank element)
        {
            _context.Bank.InsertOnSubmit(element);
            _context.SubmitChanges();
        }

        public void UpdateElement(Bank element)
        {
            Bank updateElement = GetElement(element.CodePayment);
            if (updateElement != null)
            {
                updateElement.Ammount = element.Ammount;
                updateElement.Comment = element.Comment;
                updateElement.Date = element.Date;
                _context.SubmitChanges();
            }
        }

        public void DeleteElement(int id)
        {
            Bank element = GetElement(id);
            _context.Bank.DeleteOnSubmit(element);
            _context.SubmitChanges();
        }

        public void DeleteElement(Bank element)
        {
            DeleteElement(element.CodePayment);
        }
    }
}