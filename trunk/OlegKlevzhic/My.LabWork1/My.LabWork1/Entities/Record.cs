using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My.LabWork1.Policlinic.Entities
{
	[Serializable]
	public class Record : EntityBase
	{
		public Doctor Doctor { get; set; }
		public Pacient Pacient { get; set; }
		public DateTime DateTime { get; set; }

		public Record(Doctor doctor, Pacient pacient, DateTime dateTime)
		{
			this.Doctor = doctor;
			this.Pacient = pacient;
			this.DateTime = dateTime;
		}

		public override string ToString()
		{
			return String.Format("Doctor: {0}.\nPacient: {1}.\nTime: {2}.", Doctor.ToString(), Pacient.ToString(), DateTime.ToString("HH:mm"));
		}
	}
}
