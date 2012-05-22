using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4.Models.Repository
{
    public class AgentRepository : IRepository<Agents>
    {
             ConstrCompDataContext dataContext;

        public AgentRepository()
        {
            dataContext = new ConstrCompDataContext();
        }

        public IEnumerable<Agents> GetAll()
        {
            return dataContext.Agents.AsEnumerable<Agents>();
        }

        public Agents GetById(int id)
        {
            return GetAll().SingleOrDefault(x => x.id == id);
        }

        public void Save(Agents item)
        {
            dataContext.Agents.InsertOnSubmit(item);
            dataContext.SubmitChanges();
        }

        public void Update(Agents item)
        {            
            Agents updateItem = GetById(item.id);
            if (updateItem != null)
            {
                updateItem.id = item.id;
                updateItem.name = item.name;
                dataContext.SubmitChanges();
                
            }
        }

        public void Delete(Agents item)
        {
            Agents deleteItem = GetById(item.id);
            dataContext.Agents.DeleteOnSubmit(deleteItem);
            dataContext.SubmitChanges();
            
        }
    }
}