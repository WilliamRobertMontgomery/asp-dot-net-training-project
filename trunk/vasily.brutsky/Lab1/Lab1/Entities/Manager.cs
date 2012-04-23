using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1.Entities
{
    public class Manager
    {
        private string _name;
        private int _id;


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
        public Manager()
        {
            name = "";
        }
        public Manager(int Id, string Name)
        {
            id = Id;
            name = Name;
        }



    }
}
