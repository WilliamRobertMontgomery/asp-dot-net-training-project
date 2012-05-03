using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRental.BusinessLogic
{
    public class Car
    {
        public string Id { get; set; }
        public string BrandName { get; set; }
        public string Client { get; set; }
        public string DateOfLease { get; set; }

        public Car(
            string id, string brand, string status = null, string date = null)
        {
            Id = id;
            BrandName = brand;
            Client = status;
            DateOfLease = date;
        }

        public override string ToString()
        {
            return string.Format("Id:{0}\r\nBrand Name:{1}\r\nClient:{2}\r\n{3}",
                this.Id, this.BrandName, this.Client, this.DateOfLease);
        }
    }
}
