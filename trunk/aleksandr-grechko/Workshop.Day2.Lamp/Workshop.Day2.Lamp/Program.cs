using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Workshop.Day2.Lamp
{
	class Program
	{
		static void Main(string[] args)
		{
			Lamp lamp = new Lamp();
			lamp.TurnOnLight();
			lamp.ReplaceBulb(30);
			lamp.GetState();

			Console.WriteLine();

			DeskLamp deskLamp = new DeskLamp(25, Place.Chair, true);
			deskLamp.GetState();
			deskLamp.MoveDeskLamp(Place.Floor);
			deskLamp.GetState();

			Console.WriteLine();

			LigthSource[] allLamps = { lamp, deskLamp };

			foreach (LigthSource l in allLamps)
			{
				(l as Lamp).ReplaceBulb(50);
				if (l is DeskLamp)
				{
					(l as DeskLamp).MoveDeskLamp(Place.Table);
				}
				l.TurnOffLight();
				l.GetState();
				Console.WriteLine();
			}

		}
	}
}
