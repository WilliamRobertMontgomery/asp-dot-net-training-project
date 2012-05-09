using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace My.LabWork1.Policlinic.Entities
{
	[Serializable]
	public class Doctor : EntityBase
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int Id_Specialization { get; set; }
		public List<Record> Records;

		public Doctor(int id)
		{
			this.Id = id;
			this.Records = new List<Record>();
		}

		public void Reception(object o)
		{
			bool flag = true;
			while (true)
			{
				var buf = Records.Select(x => new Tuple<Pacient, DateTime>(x.Pacient, x.DateTime));
				if (buf.Where(x => (x.Item2.Minute == DateTime.Now.Minute) && (x.Item2.Hour == DateTime.Now.Hour)).Count() != 0)
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
						Thread.Sleep(3000);
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
