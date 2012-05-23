using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using WebProject.Core;


namespace WebProject.DataAccess.Entities
{
	public class Profile : EntityBase<Guid>
	{
		public virtual Guid Id_User { get; set; }
		public virtual string FirstName { get; set; }
		public virtual string LastName { get; set; }
		public virtual string Gender { get; set; }
		public virtual DateTime BirthDate { get; set; }
		public virtual string Website { get; set; }
		public virtual string City { get; set; }
		public virtual string Country { get; set; }
		public virtual IList<Profile> Friends { get; set; }
		public virtual IList<Message> GetMessages { get; set; }
		public virtual IList<Message> SendMessages { get; set; }

		public Profile()
		{
			this.BirthDate = new DateTime().MinDate();
			this.Friends = new List<Profile>();
			this.GetMessages = new List<Message>();
			this.SendMessages = new List<Message>();
		}

		public virtual void AddFriend(Profile profile)
		{
			this.Friends.Add(profile);
			profile.Friends.Add(this);
		}

		public virtual void RemoveFriend(Profile profile)
		{
			this.Friends.Remove(profile);
			profile.Friends.Remove(this);
		}

		public virtual void SendMessage(Profile profile, string text)
		{
			Message message = new Message()
			{
				Text = text,
				SendUser = this,
				GetUser = profile,
				NameSendUser = this.FirstName + " " + this.LastName,
				NameGetUser = profile.FirstName + " " + profile.LastName
			};
			this.SendMessages.Add(message);
			profile.GetMessages.Add(message);
		}

		public virtual void RemoveMessage(Message message)
		{
			this.SendMessages.Remove(message);
			this.GetMessages.Remove(message);
		}
	}
}
