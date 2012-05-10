using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1Airport.Entities
{
    static class DBAiportDataContext
    {
        public static List<Bank> Bank = new List<Bank>();
        public static List<Planes> Planes = new List<Planes>();
        public static List<Clients> Clients = new List<Clients>();
        public static List<Reis> Reis = new List<Reis>();
        public static List<BasicReis> BasicReis = new List<BasicReis>();
    }
}
