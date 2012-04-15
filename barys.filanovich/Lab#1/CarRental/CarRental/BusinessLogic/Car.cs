using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRental.BusinessLogic
{
    public class Car
    {
        public string BrandName { get; set; }
        public string Status { get; set; }
        public string DateOfLease { get; set; }

        public Car(string brand, string status = "free", string date = null)
        {
            BrandName = brand;
            Status = status;
            DateOfLease = date;
        }

        public override string ToString()
        {
            return string.Format("Brand Name:{0}\r\nStatus:{1}\r\n{2}", 
                this.BrandName, this.Status,this.DateOfLease);
        }
    }
}
