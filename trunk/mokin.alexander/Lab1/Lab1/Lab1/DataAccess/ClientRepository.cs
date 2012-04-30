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
        private const string filePath = "Clients.txt";

        public Client GetItem(int id)
        {
            return GetAll().FirstOrDefault(client => client.id == id);
        }

        public IEnumerable<Client> GetAll()
        {
            string[] clients = null;
            string[] clientFields;
            try
            {
                clients = File.ReadAllLines(filePath);
            }
            catch
            {
               return new Client[] {new Client(0, null)}.Select(x => x);
            }
            return clients.Select(client => { clientFields = client.Split(','); 
                                              return new Client(Int32.Parse(clientFields[0]), clientFields[1]);
                                            });            
        }

        public bool Add(Client item)
        {
            var clients = GetAll();
            if (clients.First().id == 0)
            {
                clients = new Client[] { item };
            }
            else
            {
                clients = clients.Union(new Client[] { item });
            }
            StreamWriter streamWriter = new StreamWriter(filePath);
            foreach (var client in clients)
            {
                streamWriter.WriteLine(client.id.ToString() + ',' + client.name);
            }
            streamWriter.Close();
            return true;
        }

        public bool Delete(int id)
        {
            var clients = GetAll().Where(client => client.id != id);
            StreamWriter streamWriter = new StreamWriter(filePath);
            foreach (var client in clients)
            {
                streamWriter.WriteLine(client.id.ToString() + ',' + client.name);
            }
            streamWriter.Close();
            return true;
        }

        public bool Delete(Client item)
        {
            var clients = GetAll().Where(client => client.id != item.id && client.name != item.name);
            StreamWriter streamWriter = new StreamWriter(filePath);
            foreach (var client in clients)
            {
                streamWriter.WriteLine(client.id.ToString() + ',' + client.name);
            }
            streamWriter.Close();
            return true;
        }
    }
}
