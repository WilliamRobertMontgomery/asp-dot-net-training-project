using System;
using System.Text;

namespace OOP.Principles
{
	/* 
	 * An abstract class. Represents the most common properties of any worker
	 */
	abstract class Employee
	{
		protected string _personsName;
		protected string _personsSurname;

		/// <summary>
		/// abstract proprty for getting or setting name of a person
		/// </summary>
		public abstract string Name
		{
			get;
			set;
		}

		/// <summary>
		/// abstract proprty for getting or setting surnamename of a person
		/// </summary>
		public abstract string Surname
		{
			get; 
			set;
		}

		/// <summary>
		/// this method shows someone working
		/// </summary>
		/// <returns></returns>
		public abstract string Work();
	}
}
