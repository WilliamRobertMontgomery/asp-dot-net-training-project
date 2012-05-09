using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab2.Entities;

namespace Lab2.DataAccess
{
    public class ManagerRepository:IRepository<Manager>
    {
        private QuiescencyDataContext managerDataContext;

        public ManagerRepository()
        {
            managerDataContext = new QuiescencyDataContext();
        }

        public Manager GetItem(int id)
        {
            return managerDataContext.Manager.SingleOrDefault(t => t.id == id);
        }

        public IEnumerable<Manager> GetItems()
        {
            return managerDataContext.Manager.AsEnumerable<Manager>();
        }

        public void Add(Manager item)
        {
            managerDataContext.Manager.InsertOnSubmit(item);
            managerDataContext.SubmitChanges();
            
        }

        public void Remove(Manager item)
        {

            managerDataContext.Manager.DeleteOnSubmit(item);
            managerDataContext.SubmitChanges();
           
        }

        public void Remove(int id)
        {

            Manager temp = managerDataContext.Manager.SingleOrDefault(t => t.id == id);
            if (temp != null)
            {
                managerDataContext.Manager.DeleteOnSubmit(temp);
                managerDataContext.SubmitChanges();
            }
        }

        public void Update(Manager item)
        {
            Manager itemUpdate = GetItem(item.id);
            if (itemUpdate != null)
            {
                itemUpdate.name = item.name;
                managerDataContext.SubmitChanges();
            }
        }
    }
}
