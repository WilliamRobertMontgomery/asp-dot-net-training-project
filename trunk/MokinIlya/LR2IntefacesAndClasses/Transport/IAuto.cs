using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MOVING
{
    interface IAuto : ITransport
    {
        void OpenFrontRigthDoor();

        void OpenFrontLeftDoor();

        void OpenBackRigthDoor();

        void OpenBackLeftDoor();

        void CloseFrontRigthDoor();

        void CloseFrontLeftDoor();

        void CloseBackRigthDoor();

        void CloseBackLeftDoor();

        void StartTheAuto();

        void TurnOfTheAuto();
    }
}
