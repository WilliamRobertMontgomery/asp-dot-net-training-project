using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab2.Entities;

namespace Lab2.DataAccess
{
    public class ClientRepository:IRepository<Client>
    {
        private QuiescencyDataContext clientDataContext;

        public ClientRepository()
        {
            clientDataContext = new QuiescencyDataContext();
        }

        public Client GetItem(int id)
        {
            return clientDataContext.Client.SingleOrDefault(t => t.id == id);
        }

        public IEnumerable<Client> GetItems()
        {
            return clientDataContext.Client.AsEnumerable<Client>();
        }

        public void Add(Client item)
        {
            clientDataContext.Client.InsertOnSubmit(item);
            
            clientDataContext.SubmitChanges();
            
        }

        public void Remove(Client item)
        {

            clientDataContext.Client.DeleteOnSubmit(item);
            clientDataContext.SubmitChanges();
           
        }

        public void Remove(int id)
        {

            Client temp = clientDataContext.Client.SingleOrDefault(t => t.id == id);
            if (temp != null)
            {
                clientDataContext.Client.DeleteOnSubmit(temp);
                clientDataContext.SubmitChanges();
            }
        }

        public void Update(Client item)
        {
            Client itemUpdate = GetItem(item.id);
            if (itemUpdate != null)
            {
                itemUpdate.name = item.name;
                clientDataContext.SubmitChanges();
            }
        }

    
    }
}
