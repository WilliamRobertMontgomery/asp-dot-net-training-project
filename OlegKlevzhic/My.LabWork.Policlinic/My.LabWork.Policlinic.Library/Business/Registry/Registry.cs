using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using My.LabWork.Policlinic.Library.DataAccess;

namespace My.LabWork.Policlinic.Library.Business.Registry
{
	public class Registry : Repository, IRegistry
	{
		public Registry()
			: base()
		{
		}

		public string Greeting(Pacient thePacient)
		{
			return String.Format("Hello,{0}!", thePacient.ToString());
		}

		public DateTime GetTimeDoctor(int id_Doctor)
		{
			var time = GetRecordsDoctor(id_Doctor).Select(x => x.Time).DefaultIfEmpty(DateTime.Now).Max();
			if (DateTime.Now > time)
			{
				return DateTime.Now.AddMinutes(2);
			}
			else
			{
				return time.AddMinutes(2);
			}
		}

		public DateTime GetTimeSpecialization(int id_Specialization)
		{
			var time = GetRecordSpecialization(id_Specialization).Select(x => x.Time).DefaultIfEmpty(DateTime.Now).Max();

			if (DateTime.Now > time)
			{
				return DateTime.Now.AddMinutes(2);
			}
			else
			{
				return time.AddMinutes(2);
			}
		}

		public Record WriteToReceptionSpecialization(int id_Specialization, Pacient thePacient)
		{
			int idDoctor = GetRecordSpecialization(id_Specialization).OrderByDescending(x => x.Time).FirstOrDefault().Id_Doctor;
			DateTime time = GetTimeSpecialization(id_Specialization);
			Record theRecord = new Record(idDoctor, thePacient.Id, time);
			AddPacient(thePacient);
			AddRecord(theRecord);
			return theRecord;
		}

		public Record WriteToReceptionDoctor(int id_Doctor, Pacient thePacient)
		{
			AddPacient(thePacient);
			Record theRecord = new Record(id_Doctor, thePacient.Id, GetTimeDoctor(id_Doctor));
			AddRecord(theRecord);
			return theRecord;
		}
	}
}
