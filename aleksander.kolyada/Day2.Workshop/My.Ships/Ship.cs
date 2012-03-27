using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My.Ships
{
    class Ship:IShip
    {
        private string _name;            // ship name
        private int _draft;              // draft of ship
        private int _numberOfCrew;       // number of crew on ship

        // properties
        public string Name
        {
            get { return _name; }
            set { _name = value;}
        }

        public int Draft
        {
            get { return _draft; }
            set { if (value > 0) _draft = value; }
        }

        public int NumberOfCrew
        {
            get { return _numberOfCrew; }
            set { if (value > 0) _numberOfCrew = value; }
        }

        //constructors
        public Ship()
        {
            Name = "Unknown";
            Draft = 0;
            NumberOfCrew = 0;
        }

        public Ship(string name, int draft, int numberOfCrew)
        {
            this.Name = name;
            this.Draft = draft;
            this.NumberOfCrew = numberOfCrew;
        }
        
        //methods
        public virtual void sailTo(string s)
        {
            Console.WriteLine("The ship {0} with draft {1} ton sails to {2}. Number of crew - {3}.",Name, Draft, s, NumberOfCrew);
        }

        public virtual void action()
        {
            Console.WriteLine("Moves according to given course.");
        }
    }
}
