using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using My.LabWork1.Policlinic.Entities;
using My.LabWork1.Policlinic.DataAccess;
using My.LabWork1.Extentions;

namespace My.LabWork1.Policlinic.Business
{
	public class Registry
	{
		public string Greeting(Pacient pacient)
		{
			return String.Format("Hello,{0}!", pacient.ToString());
		}

		public DateTime GetTimeDoctor(int id_Doctor)
		{
			DateTime time = new Repository<Record>().GetAll().Where(x => x.Doctor.Id == id_Doctor).Select(x => x.DateTime).DefaultIfEmpty(DateTime.Now).Max();
			if (DateTime.Now > time)
			{
				return DateTime.Now.AddMinutes(2);
			}
			else
			{
				return time.AddMinutes(2);
			}
		}

		public Record WriteToReceptionDoctor(int id_Doctor, Pacient pacient)
		{
			new Repository<Pacient>().Save(pacient);
			Record theRecord = new Record(new Repository<Doctor>().Get(id_Doctor), pacient, GetTimeDoctor(id_Doctor));
			new Repository<Record>().Save(theRecord);
			var item = new Repository<Doctor>().Get(id_Doctor);
			item.Records.Add(theRecord);
			new Repository<Doctor>().Update(item);
			return theRecord;
		}

		public string MenuSpecializations()
		{
			return String.Format("0. Quit\n{0}", new Repository<Specialization>().GetAll().GetString());
		}

		public string MenuDoctors(int numberSpecialization)
		{
			var list = new Repository<Doctor>().GetAll().Where(x => x.Id_Specialization == numberSpecialization);
			return String.Format("0. Back up.\n{0}", list.GetString());
		}

		public string MenuRegistration(int numberDoctor)
		{
			var time = GetTimeDoctor(numberDoctor);
			return String.Format("{0}: {1:HH:mm}\n0. Back up.\n1. Sign on.", new Repository<Doctor>().Get(numberDoctor), time);
		}
	}
}
