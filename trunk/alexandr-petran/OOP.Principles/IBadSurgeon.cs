using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP.Principles
{
	/*
	 *  Interface provides methods of a bad surgeon
	 */
	interface IBadSurgeon
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
		string Kill();
	}
}
