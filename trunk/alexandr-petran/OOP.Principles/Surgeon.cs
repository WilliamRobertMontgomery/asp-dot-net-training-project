using System;
using System.Text;

namespace OOP.Principles
{
	/*
	 * class represents surgeon
	 */
	class Surgeon:Doctor, IGoodSurgeon,IBadSurgeon
	{
		private const string _goodWork = "Patient is completely cured.";
		private const string _badWork = "Patient is dead.. ";
		private const string _resultOfWork = "Surgeon works hard.";

		/// <summary>
		/// method shows surgeon working
		/// </summary>
		/// <returns></returns>
		public override string Work()
		{
			return _resultOfWork;
		}

		/// <summary>
		/// this is how a good doctor work
		/// </summary>
		/// <returns></returns>
		public string Cure()
		{
			return _goodWork;
		}

		/// <summary>
		/// this is how a bad doctor work
		/// </summary>
		/// <returns></returns>
		public string Kill()
		{
			return _badWork;
		}

		/// <summary>
		/// simple constructor
		/// </summary>
		/// <param name="name"></param>
		/// <param name="surname"></param>
		/// <param name="employer"></param>
		public Surgeon (string name, string surname, string employer)
		{
			Name = name;
			Surname = surname;
			Employer = employer;
		}
	}
}
