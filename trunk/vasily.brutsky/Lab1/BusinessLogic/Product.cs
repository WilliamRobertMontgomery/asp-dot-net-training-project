using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1.BusinessLogic
{
    public class Product
    {
        private string _address;
        private string _name;
        private string _status;
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

        public string address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
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
       
        public string status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }
        public Product()
        {
            address = "";
            id = 0;
            name = "";
            status = "";
        }

        public Product( int Id, string Name, string Address, string Status)
        {
            id = Id;
            address = Address;
            name = Name;
            status = Status;
        }
    }

}
