using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using My.LabWork.Policlinic.Library.DataAccess;

namespace My.LabWork.Policlinic.Library.Business.Registry
{
	public interface IRegistry : IRepository
	{
		string Greeting(Pacient thePacient);
		DateTime GetTimeDoctor(int idDoctor);
		DateTime GetTimeSpecialization(int idSpecialization);
		Record WriteToReceptionSpecialization(int idSpecialization, Pacient thePacient);
		Record WriteToReceptionDoctor(int idDoctor, Pacient thePacient);
	}
}
