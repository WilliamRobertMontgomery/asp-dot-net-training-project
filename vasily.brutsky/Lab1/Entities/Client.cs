using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1.Entities
{
    public class Client
    {
        private int _id;
        private string _name;
        //Product _product;

        public int id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public Client()
        {
            name = "";
        }
        public Client(int Id, string Name)
        {
            id = Id;
            name = Name;
        }
    }
}
