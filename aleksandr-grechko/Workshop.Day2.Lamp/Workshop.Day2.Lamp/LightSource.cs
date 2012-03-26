using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Workshop.Day2.Lamp
{
	public abstract class LigthSource
	{
		protected bool light;

		public int Brightness { get; set; }

		public abstract void TurnOnLight();
		public abstract void TurnOffLight();
		public abstract void GetState();
	}
}
