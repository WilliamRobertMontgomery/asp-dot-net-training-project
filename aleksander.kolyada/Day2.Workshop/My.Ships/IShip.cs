using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My.Ships
{
    public interface IShip
    {
        string Name { get; set; }
        int Draft { get; set; }
        int NumberOfCrew { get; set; }
        void sailTo(string s);
        void action();

    }
}
