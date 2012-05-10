using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1Airport.Entities
{
    public class BasicReis
    {
        public int CodeBasicReis;
        public DateTime Date;
        public decimal? Price;
        public int Interval;
        public string To;
        public int CodePlain;

        public Planes Planes;
    }
}
