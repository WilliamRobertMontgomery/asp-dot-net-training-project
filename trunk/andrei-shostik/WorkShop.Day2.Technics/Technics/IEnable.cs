using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Technics
{
    interface IEnable
    {
        bool IsOn();

        void TurnOn();

        void TurnOff();
    }
}
