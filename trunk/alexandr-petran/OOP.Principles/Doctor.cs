using System;
using System.Text;

namespace OOP.Principles
{
	/*
	 * class? that represents simple doctor
	 */
	class Doctor: Employee
	{
		private const string _resultOfWork = "Doctor works hard.";

		/// <summary>
		/// property for getting or setting doctor's employer
 		/// </summary>
		public string Employer
		{
			get;
			set;
		}

		/// <summary>
		/// proprty for getting or setting name of a doctor
		/// </summary>
		public override string Name
		{
			get
			{
				return _personsName;
			}
			set
			{
				_personsName = value;
			}
		}

		/// <summary>
		/// proprty for getting or setting surnamename of a doctor
		/// </summary>
		public override string Surname
		{
			get
			{
				return _personsSurname;
			}
			set
			{
				_personsSurname = value;
			}

		}

		/// <summary>
		/// method shows doctor working
		/// </summary>
		/// <returns></returns>
		public override string Work()
		{
			return _resultOfWork;
		}

	}
}
