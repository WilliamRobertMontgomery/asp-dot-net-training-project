using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My.LabWork1.Policlinic.Entities
{
	[Serializable]
	public class Specialization : EntityBase
	{
		public string NameSpecialization { get; set; }

		public Specialization(int id, string nameSpecialization)
		{
			this.Id = id;
			this.NameSpecialization = nameSpecialization;
		}
	}
}
