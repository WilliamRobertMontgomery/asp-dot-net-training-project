using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4.Models.Repository
{
    public class BuilderRepository : IRepository<Builders>
    {
             ConstrCompDataContext dataContext;

        public BuilderRepository()
        {
            dataContext = new ConstrCompDataContext();
        }

        public IEnumerable<Builders> GetAll()
        {
            return dataContext.Builders.AsEnumerable<Builders>();
        }

        public Builders GetById(int id)
        {
            return GetAll().SingleOrDefault(x => x.id == id);
        }

        public void Save(Builders item)
        {
            dataContext.Builders.InsertOnSubmit(item);
            dataContext.SubmitChanges();
        }

        public void Update(Builders item)
        {
            Builders updateItem = GetById(item.id);
            if (updateItem != null)
            {
                updateItem.id = item.id;
                updateItem.name = item.name;
                dataContext.SubmitChanges();
            }
        }

        public void Delete(Builders item)
        {
            Builders deleteItem = GetById(item.id);
            dataContext.Builders.DeleteOnSubmit(deleteItem);
            dataContext.SubmitChanges();
            
        }
    }
}