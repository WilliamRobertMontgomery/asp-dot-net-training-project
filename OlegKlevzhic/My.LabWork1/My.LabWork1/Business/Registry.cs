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
		private readonly string path = @"e:\#Worckspace\#Training\OlegKlevzhic\My.LabWork1\My.LabWork1\Data\";

		public Registry()
		{
		}

		public Registry(string path)
		{
			this.path = path;
		}

		public string Greeting(Pacient pacient)
		{
			return String.Format("Hello,{0}!", pacient.ToString());
		}

		public DateTime GetTimeDoctor(int id_Doctor)
		{
			DateTime timeNow = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);
			DateTime time = new Repository<Record>(path).GetAll().Where(x => x.Doctor.Id == id_Doctor).Select(x => x.DateTime).DefaultIfEmpty(timeNow).Max();
			if (timeNow > time)
			{
				return timeNow.AddMinutes(2);
			}
			else
			{
				return time.AddMinutes(2);
			}
		}

		public Record WriteToReceptionDoctor(int id_Doctor, Pacient pacient)
		{
			new Repository<Pacient>(path).Save(pacient);
			Record theRecord = new Record(new Repository<Doctor>(path).Get(id_Doctor), pacient, GetTimeDoctor(id_Doctor));
			new Repository<Record>(path).Save(theRecord);
			var item = new Repository<Doctor>(path).Get(id_Doctor);
			item.Records.Add(theRecord);
			new Repository<Doctor>(path).Update(item);
			return theRecord;
		}

		public string MenuSpecializations()
		{
			return String.Format("0. Quit\n{0}", new Repository<Specialization>(path).GetAll().GetString());
		}

		public string MenuDoctors(int numberSpecialization)
		{
			var list = new Repository<Doctor>(path).GetAll().Where(x => x.Id_Specialization == numberSpecialization);
			return String.Format("0. Back up.\n{0}", list.GetString());
		}

		public string MenuRegistration(int numberDoctor)
		{
			var time = GetTimeDoctor(numberDoctor);
			return String.Format("{0}: {1:HH:mm}\n0. Back up.\n1. Sign on.", new Repository<Doctor>(path).Get(numberDoctor), time);
		}
	}
}
