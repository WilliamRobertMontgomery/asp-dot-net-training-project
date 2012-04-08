using System;

namespace Technics
{
    public abstract class Technic : IEnable
    {
        private bool _switch;

        protected Technic() : this("Undefined", null) { }

        protected Technic(string manufacturer, double? cost)
        {
            ID = GetHashCode();
            Cost = cost;
            Manufacturer = manufacturer;
        }

        public int ID { get; private set; }

        public double? Cost { get; private set; }

        public string Manufacturer { get; private set; }

        public virtual bool IsOn()
        {
            return _switch;
        }

        public virtual void TurnOn()
        {
            if (_switch)
            {
                Console.WriteLine("{0} already enabled.", ID);
            }
            else
            {
                _switch = true;
                Console.WriteLine("{0} enabled", ID);
            }
        }

        public virtual void TurnOff()
        {
            if (_switch)
            {
                _switch = false;
                Console.WriteLine("{0} disabled", ID);
            }
            else
            {
                Console.WriteLine("{0} already disabled.", ID);
            }
        }

        public override string ToString()
        {
            return string.Format("ID: {0}\nManufacturer: {1}\nCost: {2}\n", ID, Manufacturer, (object)Cost ?? "null");
        }

        public override sealed int GetHashCode()
        {
            return default(int) ^ base.GetHashCode();
        }
    }
}