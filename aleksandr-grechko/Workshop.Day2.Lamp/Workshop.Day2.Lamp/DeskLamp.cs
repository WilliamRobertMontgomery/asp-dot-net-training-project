using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Workshop.Day2.Lamp
{

	public enum Place { Table, Floor, Chair };


	public class DeskLamp : Lamp
	{
		private Place place;

		public DeskLamp()
			: base()
		{
			place = Place.Table;
		}

		public DeskLamp(int brightness, Place place, bool light = false)
			: base(brightness, light)
		{
			this.place = place;
		}

		public override void TurnOnLight()
		{
			if (light)
			{
				Console.WriteLine("Desk lamp already turned on");
			}
			else
			{
				light = true;
				Console.WriteLine("Desk lamp turned on");
			}
		}

		public override void TurnOffLight()
		{
			if (light)
			{
				light = false;
				Console.WriteLine("Desk lamp turned off");
			}
			else
			{
				Console.WriteLine("Desk lamp already turned off");
			}
		}

		public override void GetState()
		{
			Console.WriteLine("Desk lamp turned " + (light ? "on" : "off") + " , brightness - " + Brightness + ", on " + place);
		}

		public override void ReplaceBulb(int newBrightness)
		{
			Brightness = newBrightness;
			Console.WriteLine("Bulb replaced in desk lamp");
		}

		public void MoveDeskLamp(Place newPlace)
		{
			place = newPlace;
			Console.WriteLine("Desk lamp moved on " + newPlace);
		}
	}
}
