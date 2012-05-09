using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My.LabWork1.Policlinic.Entities
{
	[Serializable]
	public class Pacient : EntityBase
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public IList<Record> Records;

		public Pacient()
		{
			this.Records = new List<Record>();
		}

		public override string ToString()
		{
			return String.Format("{0} {1}", FirstName, LastName);
		}
	}
}
