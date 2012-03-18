using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MOVING
{
    interface ITruck:IAuto
    {
        void SetLoad(string NameLoad);

        void LoadTheTruck();

        void UnloadTheTrack();
    }
}
