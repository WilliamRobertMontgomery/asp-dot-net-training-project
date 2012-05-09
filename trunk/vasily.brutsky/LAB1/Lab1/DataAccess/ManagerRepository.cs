using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Lab1.Entities;

namespace Lab1.DataAccess
{
    public class ManagerRepository:IRepository<Manager>
    {
        private const string Managers = "c:\\Managers.txt";

        public Manager GetItem(int id)
        {
            return GetItems()
                .FirstOrDefault(i => i.id == id);
        }

        public IEnumerable<Manager> GetItems()
        {
            string[] managers = File.ReadAllLines(Managers);
            return
                managers.Select(c =>
                {
                    string[] manager = c.Split('|');
                    return new Manager(System.Int32.Parse(manager[0]), manager[1]);
                });
            
        }

        public void Save(Manager item)
        {
            var itemString = string.Join("|", item.id, item.name) + "\n";
            File.AppendAllText(Managers, itemString);
        }

        public void Remove(Manager item)
        {
            string[] managers = File.ReadAllLines(Managers);


            IEnumerable<Manager> SelectedManagers = managers.Select(c =>
            {
                string[] manager = c.Split('|');

                return new Manager(System.Int32.Parse(manager[0]), manager[1]);
            });



            StreamWriter a = new StreamWriter(Managers, false);
            foreach (var i in SelectedManagers)
            {
                if (i.name != item.name && i.id != item.id)
                {
                    var itemString = string.Join("|", i.id, i.name) + "\n";
                    a.Write(itemString);
                }

            }


            a.Close();
        }

        public void Remove(int id)
        {
            string[] managers = File.ReadAllLines(Managers);


            IEnumerable<Manager> SelectedManagers = managers.Select(c =>
            {
                string[] manager = c.Split('|');

                return new Manager(System.Int32.Parse(manager[0]), manager[1]);
            });



            StreamWriter a = new StreamWriter(Managers, false);
            foreach (var i in SelectedManagers)
            {
                if (i.id != id)
                {
                    var itemString = string.Join("|", i.id, i.name) + "\n";
                    a.Write(itemString);
                }

            }
        }

        public void Update(Manager item)
        {
            IRepository<Manager> _managerRepository = new ManagerRepository();
            IEnumerable<Manager> managerRepository = _managerRepository.GetItems();

            Manager[] manager = managerRepository.ToArray();

            manager[item.id - 1] = item;

            StreamWriter clientRefresh = new StreamWriter(Managers);
            clientRefresh.Flush();
            clientRefresh.Close();

            foreach (var i in manager)
            {
                _managerRepository.Save(i);
            }
        }
    }
}
