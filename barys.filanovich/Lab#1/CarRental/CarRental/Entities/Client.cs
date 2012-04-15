using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRental.Entities
{
    public class Client
    {
        public string Id { get; private set; }
        public string Name { get; set; }

        public Client(string id,string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return string.Format("ID:{0}\r\nName:{1}", this.Id, this.Name);
        }

        public void Apply(string brand)
        {
            Manager.GetCar(brand,this);
        }
    }
}
