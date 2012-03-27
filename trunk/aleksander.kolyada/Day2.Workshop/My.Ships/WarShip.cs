using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My.Ships
{
    class WarShip:Ship
    {
        //field
        private int _numberOfGuns;

        //property
        public int NumberOfGuns
        {
            get { return _numberOfGuns; }
            set { _numberOfGuns = value; }
        }

        //constructors
        public WarShip()
        {
            Name = null;
            NumberOfCrew = 0;
            Draft = 0;
            NumberOfGuns = 0;
        }

        public WarShip(string name, int numberOfCrew, int draft, int numberOfGuns)
        {
            this.Name = name;
            this.NumberOfCrew = numberOfCrew;
            this.Draft = draft;
            this.NumberOfGuns = numberOfGuns;
        }

        //override methods
        public override void sailTo(string s)
        {
            Console.WriteLine("Warship {0} with draft {1} ton sails to {2}. Number of crew - {3} чел. Number of guns - {4}", Name, Draft, s, NumberOfCrew, NumberOfGuns);
        }

        public override void action()
        {
            Console.WriteLine("Takes part in the military exercises.");
        }

    }
}
