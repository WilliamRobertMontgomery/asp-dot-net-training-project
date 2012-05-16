using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab4;


namespace Lab4.Models.DataAccess
{
    public class ClientRepository:IRepository<Client>
    {
        private QuiescencyEntitiesDataContext clientDataContext;

        public ClientRepository()
        {
            clientDataContext = new QuiescencyEntitiesDataContext();
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
