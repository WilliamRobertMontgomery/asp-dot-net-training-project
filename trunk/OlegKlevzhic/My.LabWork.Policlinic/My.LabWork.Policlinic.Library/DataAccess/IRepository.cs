using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using My.LabWork.Policlinic.Library.Business;

namespace My.LabWork.Policlinic.Library.DataAccess
{
	public interface IRepository
	{
		IEnumerable<Specialization> GetSpecialization();
		Doctor GetDoctor(int id);
		IEnumerable<Doctor> GetDoctors();
		IEnumerable<Doctor> GetDoctorsSpecialization(int idSpecialization);
		IEnumerable<Record> GetRecords();
		IEnumerable<Record> GetRecordsDoctor(int idDoctor);
		IEnumerable<Record> GetRecordSpecialization(int idSpecialization);

		void AddDoctor(Doctor theDoctor);
		void AddRecord(Record theRecord);
		void AddPacient(Pacient thePacient);
		void AddSpecialization(Specialization theSpecialization);
	}
}
