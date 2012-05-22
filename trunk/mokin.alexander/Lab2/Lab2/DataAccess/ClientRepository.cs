using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1.Entities;
using System.IO;

namespace Lab1.DataAccess 
{
    public class ClientRepository : IRepository<Client>
    {
        private ConstructionCompanyDataContext constructionCompanyDataContext;

        public ClientRepository()
        {
            constructionCompanyDataContext = new ConstructionCompanyDataContext();
        }

        public Client GetItem(int id)
        {
            return GetAll().FirstOrDefault(client => client.id == id);
        }

        public IEnumerable<Client> GetAll()
        {
            return constructionCompanyDataContext.Client.AsEnumerable<Client>();
        }

        public bool Add(Client item)
        {
            if (item != null)
            {
                constructionCompanyDataContext.Client.InsertOnSubmit(item);
                constructionCompanyDataContext.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            Client clientToDelete;
            try
            {
                clientToDelete = constructionCompanyDataContext.Client.Where(client => client.id == id).First();
            }
            catch
            {
                return false;
            }
            Delete(clientToDelete);
            return true;
        }

        public bool Delete(Client item)
        {
            if (item != null)
            {
                constructionCompanyDataContext.Client.DeleteOnSubmit(item);
                constructionCompanyDataContext.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}
