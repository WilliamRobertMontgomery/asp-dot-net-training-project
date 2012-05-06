using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace My.LabWork.Policlinic.Library.Business
{
	public partial class Record
	{
		public Record(int idDoctor, int idPacient, DateTime time)
		{
			this.Id_Doctor = idDoctor;
			this.Id_Pacient = idPacient;
			this.Time = time;
		}

		public override string ToString()
		{
			return String.Format("Doctor: {0}.\n Pacient: {1}.\n Time: {2:HH:mm}.", this.Doctor.ToString(), this.Pacient.ToString(), this.Time.ToString());
		}
	}
}
