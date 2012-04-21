using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using My.LabWork.Policlinic.Library.DataAccess;
using My.LabWork.Policlinic.Library.Extentions;

namespace My.LabWork.Policlinic.Library.Business.Registry
{
	public class Registry : IRegistry
	{
		private IRepository repository;

		public Registry()
		{
			repository = new Repository();
		}

		public string Greeting(Pacient thePacient)
		{
			return String.Format("Hello,{0}!", thePacient.ToString());
		}

		public string GetSpecialization()
		{
			return repository.GetSpecialization().GetString();
		}

		public string GetDoctorsSpecialization(int id_Specialization)
		{
			return repository.GetDoctorsSpecialization(id_Specialization).GetString();
		}

		public DateTime GetTimeDoctor(int id_Doctor)
		{
			var time = repository.GetRecordsDoctor(id_Doctor).Select(x => x.Time).DefaultIfEmpty(DateTime.Now).Max();
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
			var time = repository.GetRecordSpecialization(id_Specialization).Select(x => x.Time).DefaultIfEmpty(DateTime.Now).Max();

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
			int idDoctor = repository.GetRecordSpecialization(id_Specialization).OrderByDescending(x => x.Time).FirstOrDefault().Id_Doctor;
			DateTime time = GetTimeSpecialization(id_Specialization);
			Record theRecord = new Record(idDoctor, thePacient.Id, time);
			repository.AddPacient(thePacient);
			repository.AddRecord(theRecord);
			return theRecord;
		}

		public Record WriteToReceptionDoctor(int id_Doctor, Pacient thePacient)
		{
			repository.AddPacient(thePacient);
			Record theRecord = new Record(id_Doctor, thePacient.Id, GetTimeDoctor(id_Doctor));
			repository.AddRecord(theRecord);
			return theRecord;
		}

		public Doctor GetDoctor(int id_Doctor)
		{
			return repository.GetDoctor(id_Doctor);
		}
	}
}
