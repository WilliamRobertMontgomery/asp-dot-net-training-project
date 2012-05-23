using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebProject.DataAccess.Entities
{
	public class Message : EntityBase<Guid>
	{
		public virtual Profile GetUser { get; set; }
		public virtual Profile SendUser { get; set; }
		public virtual string Text { get; set; }
		public virtual DateTime Date { get; set; }
		public virtual string NameGetUser { get; set; }
		public virtual string NameSendUser { get; set; }

		public Message()
		{
			this.Date = DateTime.Now;
		}
	}
}
