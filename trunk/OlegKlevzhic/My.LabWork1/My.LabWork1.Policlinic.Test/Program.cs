using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using My.LabWork1.Policlinic.DataAccess;
using My.LabWork1.Policlinic.Entities;

namespace My.LabWork1.Policlinic.Test
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(new Repository<Pacient>().GetAll().Count());
		}
	}
}
