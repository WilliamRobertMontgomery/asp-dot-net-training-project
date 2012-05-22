using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4.Models.Repository
{
    public class ClientRepository : IRepository<Clients>
    {
        ConstrCompDataContext dataContext;

        public ClientRepository()
        {
            dataContext = new ConstrCompDataContext();
        }

        public IEnumerable<Clients> GetAll()
        {
            return dataContext.Clients.AsEnumerable<Clients>();
        }

        public Clients GetById(int id)
        {
            return GetAll().SingleOrDefault(x => x.id == id);
        }

        public void Save(Clients item)
        {
            dataContext.Clients.InsertOnSubmit(item);
            dataContext.SubmitChanges();
        }

        public void Update(Clients item)
        {
            Clients updateItem = GetById(item.id);
            if (updateItem != null)
            {
                updateItem.id = item.id;
                updateItem.name = item.name;
                dataContext.SubmitChanges();
            }
        }

        public void Delete(Clients item)
        {
            Clients deleteItem = GetById(item.id);
            dataContext.Clients.DeleteOnSubmit(deleteItem);
            dataContext.SubmitChanges();            
        }
    }
}