using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP.Principles
{
	/*
	 * Interface provides methods of a good surgeon
	 */
	interface IGoodSurgeon
	{
		string Name
		{
			get;
			set;
		}
		string Surname
		{
			get;
			set;
		}
		string Employer
		{
			get;
			set;
		}
		string Work();
		string Cure();
	}
}
