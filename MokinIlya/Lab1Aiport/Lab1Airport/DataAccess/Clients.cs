using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1Airport.Entities;

namespace Lab1Airport
{
    public class AccessToClients : IRepository<Clients>
    {
        private int _lastId;

        public AccessToClients()
        {
            _lastId = 0;
        }

        public Clients GetElement(int id)
        {
            return DBAiportDataContext.Clients.SingleOrDefault(m => m.CodeClient == id);
        }

        public IEnumerable<Clients> GetAll()
        {
            return DBAiportDataContext.Clients;
        }

        public void AddElement(Clients element)
        {

            element.CodeClient = _lastId;
            _lastId += 1;


            if (element.Reis == null)
            {
                element.Reis = DBAiportDataContext.Reis.Find(x => x.CodeReis == element.CodeReis);
            }
            DBAiportDataContext.Clients.Add(element);
        }

        public void UpdateElement(Clients element)
        {
            int updateElementIndex = DBAiportDataContext.Clients.FindIndex(x => x == element);
            Clients updateElement = GetElement(element.CodeClient);
            if (updateElement != null)
            {
                updateElement.BookOrBuy = element.BookOrBuy;
                updateElement.CodeReis = element.CodeReis;

                DBAiportDataContext.Clients[updateElementIndex] = updateElement;
            }
        }

        public void DeleteElement(int id)
        {
            Clients element = GetElement(id);
            DBAiportDataContext.Clients.Remove(element);
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
