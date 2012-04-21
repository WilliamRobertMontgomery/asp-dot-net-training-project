using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My.LabWork.Policlinic.Library.Business.Registry
{
	public interface IRegistry
	{
		string Greeting(Pacient thePacient);
		string GetSpecialization();
		Doctor GetDoctor(int id_Doctor);
		string GetDoctorsSpecialization(int idSpecialization);
		DateTime GetTimeDoctor(int idDoctor);
		DateTime GetTimeSpecialization(int idSpecialization);
		Record WriteToReceptionSpecialization(int idSpecialization, Pacient thePacient);
		Record WriteToReceptionDoctor(int idDoctor, Pacient thePacient);
	}
}
