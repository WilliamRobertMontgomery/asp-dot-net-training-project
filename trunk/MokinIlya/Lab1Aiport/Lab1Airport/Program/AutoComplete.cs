using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1Airport.Entities;

namespace Lab1Airport
{
    static class AutoComplete
    {
        public static void Complete(ref AccessToBasicReis Reis, ref AccessToPlanes Planes)
        {
            {
                Planes el = new Entities.Planes();
                el.NumberOfSeats = 20;
                Planes.AddElement(el);
            }

            {
                Planes el = new Entities.Planes();
                el.NumberOfSeats = 40;
                Planes.AddElement(el);
            }

            {
                Planes el = new Entities.Planes();
                el.NumberOfSeats = 55;
                Planes.AddElement(el);
            }

            {
                Planes el = new Entities.Planes();
                el.NumberOfSeats = 25;
                Planes.AddElement(el);
            }

            {
                Planes el = new Entities.Planes();
                el.NumberOfSeats = 30;
                Planes.AddElement(el);
            }

            {
                Planes el = new Entities.Planes();
                el.NumberOfSeats = 40;
                Planes.AddElement(el);
            }

            {
                Planes el = new Entities.Planes();
                el.NumberOfSeats = 15;
                Planes.AddElement(el);
            }

            {
                Planes el = new Entities.Planes();
                el.NumberOfSeats = 10;
                Planes.AddElement(el);
            }

            {
                Planes el = new Entities.Planes();
                el.NumberOfSeats = 25;
                Planes.AddElement(el);
            }

            {
                Planes el = new Entities.Planes();
                el.NumberOfSeats = 30;
                Planes.AddElement(el);
            }
            {
                Planes el = new Entities.Planes();
                el.NumberOfSeats = 30;
                Planes.AddElement(el);
            }

            {
                Planes el = new Entities.Planes();
                el.NumberOfSeats = 30;
                Planes.AddElement(el);
            }

            {
                Planes el = new Entities.Planes();
                el.NumberOfSeats = 30;
                Planes.AddElement(el);
            }

            {
                Planes el = new Entities.Planes();
                el.NumberOfSeats = 30;
                Planes.AddElement(el);
            }

            {
                Planes el = new Entities.Planes();
                el.NumberOfSeats = 30;
                Planes.AddElement(el);
            }

            {
                BasicReis el = new Entities.BasicReis();
                el.Date = DateTime.Parse("2010/04/03");
                el.Price = 1500;
                el.Interval = 16;
                el.To = "Bangkok";
                el.CodePlain = 1;
                Reis.AddElement(el);
            }

            {
                BasicReis el = new Entities.BasicReis();
                el.Date = DateTime.Parse("2010/04/03");
                el.Price = 1000;
                el.Interval = 10;
                el.To = "Vladivostok";
                el.CodePlain = 1;
                Reis.AddElement(el);
            }
            {
                BasicReis el = new Entities.BasicReis();
                el.Date = DateTime.Parse("2010/04/03");
                el.Price = 2000;
                el.Interval = 15;
                el.To = "Indonezia";
                el.CodePlain = 3;
                Reis.AddElement(el);
            }
            {
                BasicReis el = new Entities.BasicReis();
                el.Date = DateTime.Parse("2010/04/03");
                el.Price = 3000;
                el.Interval = 14;
                el.To = "Florida";
                el.CodePlain = 4;
                Reis.AddElement(el);
            }
            {
                BasicReis el = new Entities.BasicReis();
                el.Date = DateTime.Parse("2010/04/03");
                el.Price = 1000;
                el.Interval = 5;
                el.To = "Minsk";
                el.CodePlain = 5;
                Reis.AddElement(el);
            }
            {
                BasicReis el = new Entities.BasicReis();
                el.Date = DateTime.Parse("2010/04/03");
                el.Price = 2000;
                el.Interval = 12;
                el.To = "NewYork";
                el.CodePlain = 6;
                Reis.AddElement(el);
            }
            {
                BasicReis el = new Entities.BasicReis();
                el.Date = DateTime.Parse("2010/04/03");
                el.Price = 4500;
                el.Interval = 10;
                el.To = "Belen";
                el.CodePlain = 7;
                Reis.AddElement(el);
            }
            {
                BasicReis el = new Entities.BasicReis();
                el.Date = DateTime.Parse("2010/04/03");
                el.Price = 3000;
                el.Interval = 5;
                el.To = "Natal";
                el.CodePlain = 1;
                Reis.AddElement(el);
            }
            {
                BasicReis el = new Entities.BasicReis();
                el.Date = DateTime.Parse("2010/04/03");
                el.Price = 1500;
                el.Interval = 8;
                el.To = "Terezina";
                el.CodePlain = 9;
                Reis.AddElement(el);
            }
            {
                BasicReis el = new Entities.BasicReis();
                el.Date = DateTime.Parse("2010/04/03");
                el.Price = 1500;
                el.Interval = 4;
                el.To = "Kipr";
                el.CodePlain = 10;
                Reis.AddElement(el);
            }




        }
    }
}
