using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1Airport
{
    class CAircrafts
    {
        public class CAircraftsItem
        {
            public CAircraftsItem(int numberOfAircraft, int numberOfSeats)
            {
                NumberOfSeats = numberOfSeats;
                NumberOfAircraft = numberOfAircraft;
            }
            public int NumberOfSeats { get; set; }
            public int NumberOfAircraft { get; set; }
        }

        public List<CAircraftsItem> AircraftsItem;

        public CAircrafts()
        {
            AircraftsItem = new List<CAircraftsItem>();
        }

        public bool Add(int NumberOfAircraft, int NumberOfSeats)
        {
            AircraftsItem.Add(new CAircraftsItem(NumberOfAircraft, NumberOfSeats));
            return true;
        }
    }
}
