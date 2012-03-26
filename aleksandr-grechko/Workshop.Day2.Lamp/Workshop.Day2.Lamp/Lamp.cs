using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Workshop.Day2.Lamp
{
	public class Lamp : LigthSource
	{
		public Lamp()
		{
			Brightness = 10;
			light = false;
		}

		public Lamp(int brightness, bool light = false)
		{
			Brightness = brightness;
			this.light = light;
		}

		public override void TurnOnLight()
		{
			if (light)
			{
				Console.WriteLine("Lamp already turned on");
			}
			else
			{
				light = true;
				Console.WriteLine("Lamp turned on");
			}
		}

		public override void TurnOffLight()
		{
			if (light)
			{
				light = false;
				Console.WriteLine("Lamp turned off");
			}
			else
			{
				Console.WriteLine("Lamp already turned off");
			}
		}

		public override void GetState()
		{
			Console.WriteLine("Lamp turned " + (light ? "on" : "off") + " , brightness - " + Brightness);
		}

		public virtual void ReplaceBulb(int newBrightness)
		{
			Brightness = newBrightness;
			Console.WriteLine("Bulb replaced in lamp");
		}
	}
}
