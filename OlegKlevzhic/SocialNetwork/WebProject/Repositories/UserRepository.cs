using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebProject.DataAccess.Entities;
using WebProject.DataAccess.Repositories;
using NHibernate;

namespace WebProject.Repositories
{
	public class UserRepository : Repository<User>
	{
		private ISession _session;

		public UserRepository(ISession session)
			: base(session)
		{
			_session = session;
		}

		public User GetUserByUserName(string username)
		{
			User user = null;
			user = _session.CreateCriteria(typeof(User))
							.Add(NHibernate.Criterion.Restrictions.Eq("UserName", username))
							.UniqueResult<User>();
			return user;
		}
	}
}