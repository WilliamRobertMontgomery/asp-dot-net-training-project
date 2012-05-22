using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4.Models.Repository
{
    public class ContractRepository : IRepository<Contracts>
    {
             ConstrCompDataContext dataContext;

        public ContractRepository()
        {
            dataContext = new ConstrCompDataContext();
        }

        public IEnumerable<Contracts> GetAll()
        {
            return dataContext.Contracts.AsEnumerable<Contracts>();
        }

        public Contracts GetById(int id)
        {
            return GetAll().SingleOrDefault(x => x.id == id);
        }

        public void Save(Contracts item)
        {
            dataContext.Contracts.InsertOnSubmit(item);
            dataContext.SubmitChanges();
        }

        public void Update(Contracts item)
        {
            Contracts updateItem = GetById(item.id);
            if (updateItem != null)
            {
                updateItem.id = item.id;
                updateItem.agentId = item.agentId;
                updateItem.Agents = item.Agents;
                updateItem.builderId = item.builderId;
                updateItem.Builders = item.Builders;
                updateItem.clientId = item.clientId;
                updateItem.Clients = item.Clients;
                dataContext.SubmitChanges();
            }
        }

        public void Delete(Contracts item)
        {
            Contracts deleteItem = GetById(item.id);
            dataContext.Contracts.DeleteOnSubmit(deleteItem);
            dataContext.SubmitChanges();
            
        }
    }
}