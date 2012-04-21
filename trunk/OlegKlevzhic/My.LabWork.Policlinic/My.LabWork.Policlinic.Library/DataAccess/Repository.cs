using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using My.LabWork.Policlinic.Library.Business;

namespace My.LabWork.Policlinic.Library.DataAccess
{
	public class Repository : IRepository
	{
		private PoliclinicDataContext context;

		public Repository()
		{
			this.context = new PoliclinicDataContext();
		}

		public Doctor GetDoctor(int id_Doctor)
		{
			return context.Doctors.SingleOrDefault(x => x.Id == id_Doctor);
		}

		public IEnumerable<Doctor> GetDoctors()
		{
			return context.Doctors;
		}

		public IEnumerable<Doctor> GetDoctorsSpecialization(int id_Specialization)
		{
			return context.Doctors.Where(x => x.Id_Specialization == id_Specialization);
		}

		public IEnumerable<Specialization> GetSpecialization()
		{
			return context.Specializations;
		}

		public IEnumerable<Record> GetRecords()
		{
			return context.Records;
		}

		public IEnumerable<Record> GetRecordsDoctor(int id_Doctor)
		{
			return context.Records.Where(x => x.Id_Doctor == id_Doctor);
		}

		public IEnumerable<Record> GetRecordSpecialization(int id_Specialization)
		{
			return context.Records.Where(x => x.Doctor.Id_Specialization == id_Specialization);
		}

		public void AddDoctor(Doctor doctor)
		{
			context.Doctors.InsertOnSubmit(doctor);
			context.SubmitChanges();
		}

		public void AddRecord(Record record)
		{
			context.Records.InsertOnSubmit(record);
			context.SubmitChanges();
		}

		public void AddPacient(Pacient pacient)
		{
			context.Pacients.InsertOnSubmit(pacient);
			context.SubmitChanges();
		}

		public void AddSpecialization(Specialization specialization)
		{
			context.Specializations.InsertOnSubmit(specialization);
			context.SubmitChanges();
		}
	}
}
