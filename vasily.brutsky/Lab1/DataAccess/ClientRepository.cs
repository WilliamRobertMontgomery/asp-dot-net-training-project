using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Lab1.Entities;

namespace Lab1.DataAccess
{
    public class ClientRepository : IRepository<Client>
    {
        private const string Clients = "c:\\Clients.txt";

        public Client GetItem(int id)
        {
            return GetItems()
                .FirstOrDefault(i => i.id == id);
        }

        public IEnumerable<Client> GetItems()
        {
            string[] clients = File.ReadAllLines(Clients);
            return
                clients.Select(c =>
                {
                    string[] client = c.Split('|');
                    return new Client(System.Int32.Parse(client[0]),client[1]);
                }
                );
        }

        public void Save(Client item)
        {
            var itemString = string.Join("|",item.id, item.name) + "\n";
            File.AppendAllText(Clients, itemString);
        }

        public void Remove(Client item)
        {
            string[] clients = File.ReadAllLines(Clients);
                 
            IEnumerable< Client> SelectedClients = clients.Select(c =>
            {
                string[] client = c.Split('|');
                
                return new Client(System.Int32.Parse(client[0]), client[1]);
            });

            StreamWriter a = new StreamWriter(Clients,false);
            foreach (var i in SelectedClients)
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

            string[] clients = File.ReadAllLines(Clients);

            IEnumerable<Client> SelectedClients = clients.Select(c =>
            {
                string[] client = c.Split('|');

                return new Client(System.Int32.Parse( client[0]), client[1]);
            });

            StreamWriter a = new StreamWriter(Clients, false);
            foreach (var i in SelectedClients)
            {
                if ( i.id != id)
                {
                    var itemString = string.Join("|", i.id, i.name) + "\n";
                    a.Write(itemString);
                }

            }

            a.Close();
            
        }

        public void Update(Client item)
        {
            IRepository<Client> _clientRepository = new ClientRepository();
            IEnumerable<Client> clientRepository = _clientRepository.GetItems();

            Client[] client = clientRepository.ToArray();

            client[item.id - 1] = item;

            StreamWriter clientRefresh = new StreamWriter(Clients);
            clientRefresh.Flush();
            clientRefresh.Close();

            foreach (var i in client)
            {
                _clientRepository.Save(i);
            }


        }
    }
}
