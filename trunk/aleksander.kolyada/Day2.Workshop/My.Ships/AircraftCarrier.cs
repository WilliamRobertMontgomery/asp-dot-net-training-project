using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My.Ships
{
    class AircraftCarrier:WarShip
    {
        //field
        private int _numberOfAircrafts;

        //property
        public int NumberOfAircrafts
        {
            get { return _numberOfAircrafts; }
            set { _numberOfAircrafts = value; }
        }

        //constructors
        public AircraftCarrier()
        {
            Name = null;
            NumberOfCrew = 0;
            Draft = 0;
            NumberOfAircrafts = 0;
        }

        public AircraftCarrier(string name, int numberOfCrew, int draft, int numberOfAircrafts)
        {
            this.Name = name;
            this.NumberOfCrew = numberOfCrew;
            this.Draft = draft;
            this.NumberOfAircrafts = numberOfAircrafts;
        }

        //override methods
        public override void sailTo(string s)
        {
            Console.WriteLine("Aircraft Carrier {0} with draft {1} ton sails to {2}. Number of crew - {3}. Number of aircrafts - {4}", Name, Draft, s, NumberOfCrew, NumberOfAircrafts);
        }

        public override void action()
        {
            Console.WriteLine("Provides air defense for maritime links.");
        }

    }
}
