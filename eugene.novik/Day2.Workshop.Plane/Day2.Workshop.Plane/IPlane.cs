using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day2.Workshop.Plane
{
	interface IPlane
	{
		void Takeoff();
		void FlyTo(string target);
		void Land();
	}
}
