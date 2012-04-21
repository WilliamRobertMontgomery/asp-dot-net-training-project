using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarRental.Entities;
using System.IO;

namespace CarRental.DataAccess
{
    public class ClientRepository : IRepository<Client>
    {
        const string extension = ".clt";

        public void Save(Client item)
        {
            StreamWriter fileWriter = new StreamWriter(item.Id + extension, false);
            fileWriter.Write("{0}\r\n{1}", item.Id, item.Name);
            fileWriter.Close();
        }

        public Client[] Read()
        {
            Client[] clients;

            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*"+extension);
            
            clients=new Client[files.Length];

            for (int i = 0; i < files.Length; i++)
            {
                StreamReader clientFile = new StreamReader(files[i]);
                string clientInfo = clientFile.ReadToEnd();
                string[] clientString = clientInfo.Split(new string[] { "\r\n" }, System.StringSplitOptions.RemoveEmptyEntries);
                clientFile.Close();

                clients[i] = new Client(clientString[0], clientString[1]);
            }

            return clients;
        }

        public void Remove(Client item)
        {
            File.Delete(item.Id+".clt");
        }
    }
}
