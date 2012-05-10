using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1Airport.Repository;

namespace Lab1Airport
{
    public class CClients:IRepository<Clients>
    {
        private DBAiportDataContext _context;

        public CClients()
        {
            _context = new DBAiportDataContext();
        }

        public Clients GetElement(int id)
        {
            return _context.Clients.SingleOrDefault(m => m.CodeClient == id);
        }

        public IEnumerable<Clients> GetAll()
        {
            return _context.Clients.AsEnumerable<Clients>();
        }

        public void AddElement(Clients element)
        {
            _context.Clients.InsertOnSubmit(element);
            _context.SubmitChanges();
        }

        public void UpdateElement(Clients element)
        {
            Clients updateElement = GetElement(element.CodeClient);
            if (updateElement != null)
            {
                updateElement.BookOrBuy = element.BookOrBuy;
                updateElement.CodeReis = element.CodeReis;
                _context.SubmitChanges();
            }
        }

        public void DeleteElement(int id)
        {
            Clients element = GetElement(id);
            _context.Clients.DeleteOnSubmit(element);
            _context.SubmitChanges();
        }

        public void DeleteElement(Clients element)
        {
            DeleteElement(element.CodeClient);
        }

        public void OutToConsole()
        {
            var clients = GetAll();
            foreach (var NClient in clients)
            {
                Console.SetCursorPosition(60, Console.CursorTop);
                Console.WriteLine(String.Format("{0} {1}", NClient.CodeClient, ((bool)NClient.BookOrBuy ? "Куплен" : "Бронирован")));
            }
            Console.SetCursorPosition(0, 0);
        }
    }
}
