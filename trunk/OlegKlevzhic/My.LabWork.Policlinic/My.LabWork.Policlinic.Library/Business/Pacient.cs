using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My.LabWork.Policlinic.Library.Business
{
	public partial class Pacient
	{
		public Pacient(string firstName, string lastName)
			: this()
		{
			this.FirstName = firstName;
			this.LastName = lastName;
		}

		public override string ToString()
		{
			return String.Format("{0} {1}", FirstName, LastName);
		}
	}
}
