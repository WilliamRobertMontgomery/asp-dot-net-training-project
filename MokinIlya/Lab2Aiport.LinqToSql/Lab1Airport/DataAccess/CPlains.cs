using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1Airport.Repository;

namespace Lab1Airport
{
    public class CPlains:IRepository<Plains>
    {
        private DBAiportDataContext _context;

        public CPlains()
        {
            _context = new DBAiportDataContext();
        }

        public Plains GetElement(int id)
        {
            return _context.Plains.SingleOrDefault(m => m.CodePlane == id);
        }

        public IEnumerable<Plains> GetAll()
        {
            return _context.Plains.AsEnumerable<Plains>();
        }

        public void AddElement(Plains element)
        {
            _context.Plains.InsertOnSubmit(element);
            _context.SubmitChanges();
        }

        public void UpdateElement(Plains element)
        {
            Plains updateElement = GetElement(element.CodePlane);
            if (updateElement != null)
            {
                updateElement.NumberOfSeats = element.NumberOfSeats;
                _context.SubmitChanges();
            }
        }

        public void DeleteElement(int id)
        {
            Plains element = GetElement(id);
            _context.Plains.DeleteOnSubmit(element);
            _context.SubmitChanges();
        }

        public void DeleteElement(Plains element)
        {
            DeleteElement(element.CodePlane);
        }
    }
}
