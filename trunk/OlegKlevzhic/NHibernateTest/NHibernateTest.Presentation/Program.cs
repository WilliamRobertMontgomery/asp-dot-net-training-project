using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernateTest.Entities;
using NHibernateTest.DataAccess;
using Repository;

namespace NHibernateTest.Presentation
{
	class Program
	{
		static void Main(string[] args)
		{
			SessionConfig config = new SessionConfig();
			ISession session = config.OpenSession();

			using (ITransaction transaction = session.BeginTransaction())
			{
				List<Doctor> doctorList = new List<Doctor>
                {
                    new Doctor {FirstName = "Michael", LastName="Jhonson"},
                    new Doctor {FirstName = "Anna", LastName="Nicolson"},
                    new Doctor {FirstName = "Jhon", LastName="Travolta"},
                };

				List<Pacient> pacientList = new List<Pacient>
                {
                    new Pacient { FirstName = "John", LastName="Smith"},
                    new Pacient { FirstName = "Ivan", LastName="Ivanov"},
                    new Pacient { FirstName = "Igor", LastName="Nikolaev"},
                };

				Record record = new Record { Doctor = doctorList.Last(), Pacient = pacientList.First(), Time = DateTime.Now };

				IRepository<Doctor> doctors = new Repository<Doctor>(session);
				doctors.Save(doctorList);

				IRepository<Pacient> pacients = new Repository<Pacient>(session);
				pacients.Save(pacientList);

				IRepository<Record> records = new Repository<Record>(session);
				records.Save(record);

				transaction.Commit();
			}

			((List<Doctor>)(new Repository<Doctor>(session)).ReadAll()).ForEach(x => Console.WriteLine(x.LastName));
			Console.ReadLine();

			IRepository<Pacient> pacients1 = new Repository<Pacient>(session);
			((List<Pacient>)(new Repository<Pacient>(session)).ReadAll()).ForEach(x => Console.WriteLine(x.LastName));

			Console.ReadLine();
		}
	}
}
