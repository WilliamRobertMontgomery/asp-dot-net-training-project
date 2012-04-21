using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using My.LabWork.Policlinic.Library.Business;

namespace My.LabWork.Policlinic.Library.Extentions
{
	public static class Extentions
	{
		public static string GetString(this IEnumerable<Specialization> specializations)
		{
			string result = String.Empty;
			foreach (var specialization in specializations)
			{
				result += String.Format("{0}. {1}\n", specialization.Id, specialization.NameSpecialization);
			}
			return result;
		}

		public static string GetString(this IEnumerable<Doctor> doctors)
		{
			string result = String.Empty;
			foreach (var doctor in doctors)
			{
				result += String.Format("{0}. {1}\n", doctor.Id, doctor.ToString());
			}
			return result;
		}
	}
}
