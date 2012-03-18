using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MOVING
{
    interface ITransport
    {
        void MoveUpTo(int delt);

        void MoveDownTo(int delt);

        void MoveLeftTo(int delt);

        void MoveRightTo(int delt);
    }
}
