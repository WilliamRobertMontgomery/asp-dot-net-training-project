using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1.Entities
{
    public class Client
    {
        public int id { get; private set; }
        public string name { get; set; }

        public Client(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public override string ToString()
        {
            return string.Format("Client name: {0}\n", this.name);
        }

        public override bool Equals(Object obj)
        {
            Client client = (Client)obj;
            return client.id == client.id && client.name == client.name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
