using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4.Models.Repository
{
    public class ProjectRepository : IRepository<Projects>
    {
        ConstrCompDataContext dataContext;

        public ProjectRepository()
        {
            dataContext = new ConstrCompDataContext();
        }

        public IEnumerable<Projects> GetAll()
        {
            return dataContext.Projects.AsEnumerable<Projects>();
        }

        public Projects GetById(int id)
        {
            return GetAll().SingleOrDefault(x => x.id == id);
        }

        public void Save(Projects item)
        {
            dataContext.Projects.InsertOnSubmit(item);
            dataContext.SubmitChanges();
        }

        public void Update(Projects item)
        {
            Projects updateItem = GetById(item.id);
            if (updateItem != null)
            {
                updateItem.id = item.id;
                updateItem.name = item.name;
                updateItem.deadline = item.deadline;
                updateItem.description = item.description;
                dataContext.SubmitChanges();
            }
        }

        public void Delete(Projects item)
        {
            Projects deleteItem = GetById(item.id);
            dataContext.Projects.DeleteOnSubmit(deleteItem);
            dataContext.SubmitChanges();
            
        }
    }
}