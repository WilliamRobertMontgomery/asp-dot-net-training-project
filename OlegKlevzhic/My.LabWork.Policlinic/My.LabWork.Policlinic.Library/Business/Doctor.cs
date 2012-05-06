using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Threading;

namespace My.LabWork.Policlinic.Library.Business
{
	public partial class Doctor
	{
		public Doctor(string firstName, string lastName, int id_Specialization)
			: this()
		{
			this._FirstName = firstName;
			this._LastName = lastName;
			this._Id_Specialization = id_Specialization;
		}

		public void Reception(object o)
		{
			bool flag = true;
			while (true)
			{
				var buf = Records.Select(x => new Tuple<Pacient, DateTime>(x.Pacient, x.Time));
				if (buf.Where(x => (x.Item2.Minute == DateTime.Now.Minute) && (x.Item2.Hour == DateTime.Now.Hour) && (x.Item2.Second == DateTime.Now.Second)).Count() != 0)
				{
					int i = 0;
					while (i < 16)
					{
						if (flag)
						{
							Console.Write("Reception");
							flag = false;
						}
						Console.Write(".");
						Thread.Sleep(5000);
						i++;
						if (i == 16)
						{
							Console.Write("OK!");
						}
					}
				}
			}
		}

		public override string ToString()
		{
			return String.Format("{0} {1}", FirstName, LastName);
		}
	}
}
